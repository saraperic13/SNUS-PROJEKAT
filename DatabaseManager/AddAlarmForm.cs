using ScadaCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseManager
{
    public partial class AddAlarmForm : Form
    {
        private Tag selectedTag;
        private Alarm newAlarm;
        public AddAlarmForm(Tag tag)
        {
            InitializeComponent();
            selectedTag = tag;
        }

        private void buttonSaveAlarm_Click(object sender, EventArgs e)
        {
            Alarm alarm;
            double num;
            if (string.IsNullOrEmpty(textBoxAlarmID.Text))
            {
                ShowErrorDialog("You must enter an ID!");
            }
            else if (string.IsNullOrEmpty(textBoxLow.Text) || !double.TryParse(textBoxLow.Text, out num))
            {
                ShowErrorDialog("You must enter a valid low limit!");
            }
            else if (string.IsNullOrEmpty(textBoxHigh.Text) || !double.TryParse(textBoxLow.Text, out num))
            {
                ShowErrorDialog("You must enter a valid high limit!");
            }
            else
            {
                alarm = new Alarm(textBoxAlarmID.Text, selectedTag.TagId, Convert.ToDouble(textBoxLow.Text),
                    Convert.ToDouble(textBoxHigh.Text));
               
                if (!DBManagerForm.proxy.AddAlarm(alarm)) ShowErrorDialog("You must enter a unique alarm ID!");
  
                else
                {
                    newAlarm = alarm;
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private void ShowErrorDialog(string v)
        {
            MessageBox.Show(v, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public Alarm NewAlarm
        {
            get { return newAlarm; }
            set { newAlarm = value; }
        }
    }
}
