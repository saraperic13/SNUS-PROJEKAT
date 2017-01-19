using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.ServiceModel;
using ScadaCommon;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Trending
{
    public partial class TrendingForm : Form
    {
        public delegate void DeleteSeriesCallBack();

        private Thread graphThread;
        private Dictionary<string, double[]> tagLines = new Dictionary<string, double[]>();
        List<Tag> tags;
        List<Tag> updatedTags;

        Dictionary<string, double> tagValues;

        static object locker = new object();
       
        private ITrending proxy;
        public delegate void TagValueChandedEvent(Tag tag);

        public TrendingForm()
        {
            Uri address = new Uri("net.tcp://" + Constants.IPAddress + ":4002/ITrending");

            NetTcpBinding binding = new NetTcpBinding { Security = { Mode = SecurityMode.None } };

            ChannelFactory<ITrending> factory = new ChannelFactory<ITrending>
                (binding, new EndpointAddress(address));
            proxy = factory.CreateChannel();

            InitializeComponent();

            tags = proxy.GetScanningTags();
            tagValues = proxy.GetScanningTagValues(tags);

            graphThread = new Thread(new ThreadStart(this.PopulateValueArrays));
            graphThread.IsBackground = true;
            graphThread.Start();

        }


        private void CheckForUpdate() {
            
            if (proxy.CheckUpdatedValueFlag())
            {
                    
                lock (locker)
                {
                    tags = proxy.GetScanningTags();
                    updatedTags = new List<Tag>(tags);
                    tagValues = proxy.GetScanningTagValues(tags);

                    for (int i = 0; i < tags.Count; i++)
                    {
                        if (tags[i] is InputTag && !((InputTag)tags[i]).Scan) RemoveTagById(tags[i].TagId);
                      
                    }
                    tags = updatedTags;
                    tagValues = proxy.GetScanningTagValues(tags);

                    PopulateSeries();
                    proxy.SeenUpdatedValueFlag();
                }
            }
        }   


        private int RemoveTagById(string tagId)
        {
            lock (locker) {
                for (int i = 0; i< updatedTags.Count; i++) {
                    if (updatedTags[i].TagId.Equals(tagId))
                    {
                        updatedTags.RemoveAt(i);
                        return i;
                    }
                }
            }
            return -1;
        }

        
        private void PopulateSeries() {

            if (trendingChart.InvokeRequired)
            {
                DeleteSeriesCallBack callback = new DeleteSeriesCallBack(PopulateSeries);
                this.Invoke(callback);
                return;
            }
            bool found = false;
            List<Series> seriesToRemove = new List<Series>();

            foreach (var series in trendingChart.Series) {
                found = false;
                foreach (Tag tag in tags) {
                    if (series.Name.Equals(tag.TagId)) {
                        found = true; break;
                    }

                }
                if (!found) seriesToRemove.Add(series);
                
            }
            foreach (Series s in seriesToRemove) {
                trendingChart.Legends.Remove(trendingChart.Legends.FindByName(s.Name));
                trendingChart.Series.Remove(s);
                tagLines.Remove(s.Name);
            }
                foreach (Tag t in tags)
                {
                    if (trendingChart.Series.FindByName(t.TagId) == null) { 
                    
                        Series s = new Series(t.TagId);
                        s.BorderWidth = 3;
                        s.BorderDashStyle = ChartDashStyle.Solid;
                   
                        s.ChartType = SeriesChartType.FastLine;
                        trendingChart.Series.Add(s);
                        tagLines[t.TagId] = new double[100];

                        try { trendingChart.Legends.Add(new Legend(t.TagId)); } catch (Exception) { continue; }
                        
                    }

                }
            
        }


        private void PopulateValueArrays(){

            PopulateSeries();
            while (true) {
                tagValues = proxy.GetScanningTagValues(tags);
                CheckForUpdate();
               
                foreach (var lineName in tagLines.Keys)
                {
                    tagLines[lineName][tagLines[lineName].Length - 1] = Math.Round(tagValues[lineName], 0);
                    Array.Copy(tagLines[lineName], 1, tagLines[lineName], 0, tagLines[lineName].Length - 1);
                }
                
                if (trendingChart.IsHandleCreated) this.Invoke((MethodInvoker)delegate { UpdateChart(); });
              
                
                Thread.Sleep(1000);
            }
       }


        private void UpdateChart()
        {
            DateTime timeStamp = DateTime.Now;
            lock (locker)
            {
                foreach (var serie in trendingChart.Series)
                {
                    serie.Points.Clear();
                    for (int i = 0; i < tagLines[serie.Name].Length - 1; ++i) serie.Points.AddY(tagLines[serie.Name][i]);
                    
                }
            }
           
        }
        
        
    }

}


        
        