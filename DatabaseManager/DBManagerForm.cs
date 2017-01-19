using ScadaCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseManager
{
    public delegate void TagListChangedHandler(Tag tag);
    public partial class DBManagerForm : Form
    {
        public static IDatabaseManager proxy;
        private Tag lastSelectedTag;

        private List<Tag> listedTags;

        public DBManagerForm()
        {
            Uri address = new Uri("net.tcp://" + Constants.IPAddress + ":4001/IDatabaseManager");
            NetTcpBinding binding = new NetTcpBinding { Security = { Mode = SecurityMode.None } };

            ChannelFactory<IDatabaseManager> factory = new ChannelFactory<IDatabaseManager>
                (binding, new EndpointAddress(address));
            proxy = factory.CreateChannel();

            listedTags = new List<Tag>();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listViewTags.View = View.Details;
            listViewAlarms.View = View.Details;

            listViewTags.Columns.Add("Tag ID", listViewTags.Size.Width, HorizontalAlignment.Left);
            listViewAlarms.Columns.Add("Alarm ID", listViewAlarms.Size.Width / 3, HorizontalAlignment.Left);
            listViewAlarms.Columns.Add("Low", listViewAlarms.Size.Width / 3, HorizontalAlignment.Left);
            listViewAlarms.Columns.Add("High", listViewAlarms.Size.Width / 3, HorizontalAlignment.Left);


            listedTags = proxy.GetTags();
            if (listedTags.Count == 0) button1.Enabled = false;

            buttonAddAlarm.Enabled = false;
            buttonRemoveAlarm.Enabled = false;

            foreach (Tag tag in listedTags) listViewTags.Items.Add(new ListViewItem(tag.TagId){ Tag = tag});
        }


        private void listViewTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewAlarms.Items.Clear();
            buttonRemoveAlarm.Enabled = false;
            buttonAddAlarm.Enabled = false;
            if (listViewTags.SelectedItems.Count > 0)
            {
                lastSelectedTag = ((Tag)listViewTags.SelectedItems[0].Tag);
            }
            try
            {
                InputTag itag = (InputTag)listViewTags.SelectedItems[0].Tag;
                if (itag != null)
                {
                    if(itag.Alarms.Count > 0) buttonRemoveAlarm.Enabled = true;
                    buttonAddAlarm.Enabled = true;
                    
                }

                if (itag == null || itag.Alarms.Count == 0) return;

                
                foreach (Alarm alarm in itag.Alarms)
                {
                    var newItem = new ListViewItem(alarm.AlarmId);
                    newItem.SubItems.Add(alarm.Low.ToString());
                    newItem.SubItems.Add(alarm.High.ToString());

                    listViewAlarms.Items.Add(newItem);
                   
                }
                
            }
            catch (Exception) { return; }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            AddTagForm form = new AddTagForm("Add", null);
            if (form.ShowDialog() == DialogResult.OK){

                listViewTags.Items.Add(new ListViewItem(form.NewTag.TagId) { Tag = form.NewTag });
            }

        }


        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (listViewTags.SelectedItems.Count > 0)
            {
                var item = listViewTags.SelectedItems[0];
                var tagForm = new AddTagForm("Update", item);
                tagForm.ShowDialog();
            }
  
        }

        public void OnAddTag(Tag tag) {
            if (listViewTags.InvokeRequired)
            {
                var handler = new TagListChangedHandler(OnAddTag);
                BeginInvoke(handler, tag);
                return;
            }

            if (listViewTags.FindItemWithText(tag.TagId) != null)
            {
                return;
            }

            var newItem = new ListViewItem(tag.TagId) { Tag = tag };
            listViewTags.Items.Add(newItem);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (listViewTags.SelectedItems.Count > 0)
            {
                var item = listViewTags.SelectedItems[0];
                var tagId = item.Text;
                listViewTags.Items.Remove(item);
                proxy.RemoveTag(tagId);
            }
        }

        
        private void buttonAddAlarm_Click(object sender, EventArgs e)
        {
            AddAlarmForm form = new AddAlarmForm(lastSelectedTag);
            if (form.ShowDialog() == DialogResult.OK)
            {
                foreach (Tag t in listedTags) {
                    if (t.TagId.Equals(form.NewAlarm.TagId)) ((InputTag)t).AddAlarm(form.NewAlarm);
                }
                var item = new ListViewItem(form.NewAlarm.AlarmId) { Tag = form.NewAlarm }; 
                item.SubItems.Add(form.NewAlarm.Low.ToString());
                item.SubItems.Add(form.NewAlarm.High.ToString());
                listViewAlarms.Items.Add(item);
                
                
            }

        }


        private void buttonRemoveAlarm_Click(object sender, EventArgs e)
        {
            if (listViewAlarms.SelectedItems.Count > 0)
            {
                var item = listViewAlarms.SelectedItems[0];
                var alarmId = item.Text;
                listViewAlarms.Items.Remove(item);
                proxy.RemoveAlarm(lastSelectedTag.TagId, alarmId);
                try { ((InputTag)lastSelectedTag).RemoveAlarm(alarmId); } catch (Exception) { return; }
            }

        }

        public List<Alarm> ListedTags { get; set; }
    }
}