using ScadaCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseManager
{
    enum TagType { AnalogInput, AnalpgOutput, DigitalInput, DigitalOutput};

    public partial class AddTagForm : Form
    {
        string operation;
        Tag tag = null;
        Tag newTag;

        public AddTagForm(string oper, ListViewItem tg)
        {

            this.operation = oper;
            InitializeComponent();
            if (!operation.Equals("Add")) { 
                this.tag = (Tag)tg.Tag;
                PopulateFields(tag);
            }

        }


        private void PopulateFields(Tag tag)
        {
            textBoxDescription.Text = tag.Description;
            textBoxTagId.Text = tag.TagId;
            
            textBoxTagAddress.Text = tag.IOAddress;

            switch (tag.GetType().Name.ToString()) {
                case "AnalogInput":
                    comboBoxTagType.Text = "Analog Input";
                    textBoxHighLimit.Text = ((AnalogInput)tag).HighLimit.ToString();
                    textBoxLowLimit.Text = ((AnalogInput)tag).LowLimit.ToString();
                    checkBoxAutoMode.Checked = ((AnalogInput)tag).Auto ? true : false;
                    checkBoxOnScan.Checked = ((AnalogInput)tag).Scan ? true : false;
                    textBoxScanTime.Text = ((AnalogInput)tag).ScanTime.ToString();
                    comboBoxFunctionType.Text = ((AnalogInput)tag).Function;
                    textBoxUnits.Text = ((AnalogInput)tag).Units;
                    textBoxInitialValue.Enabled = !((AnalogInput)tag).Auto;

                    break;
                case "AnalogOutput":
                    comboBoxTagType.Text = "Analog Output";
                    textBoxHighLimit.Text = ((AnalogOutput)tag).HighLimit.ToString();
                    textBoxLowLimit.Text = ((AnalogOutput)tag).LowLimit.ToString();
                    checkBoxAutoMode.Enabled = false;
                    checkBoxOnScan.Enabled = false;
                    textBoxScanTime.Enabled = false;
                    textBoxInitialValue.Text = ((AnalogOutput)tag).InitialValue.ToString();
                    comboBoxFunctionType.Enabled = false;
                    textBoxUnits.Text = ((AnalogOutput)tag).Units.ToString();
                    break;
                case "DigitalInput":
                    comboBoxTagType.Text = "Digital Input";
                    textBoxHighLimit.Enabled = false;
                    textBoxLowLimit.Enabled = false;
                    checkBoxAutoMode.Checked = ((DigitalInput)tag).Auto ? true : false;
                    checkBoxOnScan.Checked = ((DigitalInput)tag).Scan ? true : false;
                    textBoxScanTime.Text = ((DigitalInput)tag).ScanTime.ToString();
                    comboBoxFunctionType.Text = ((DigitalInput)tag).Function;
                    textBoxInitialValue.Enabled = !((DigitalInput)tag).Auto;
                    break;
                case "DigitalOutput":
                    comboBoxTagType.Text = "Digital Output";
                    textBoxHighLimit.Enabled = false;
                    textBoxLowLimit.Enabled = false;
                    checkBoxAutoMode.Enabled = false;
                    checkBoxOnScan.Enabled = false;
                    textBoxScanTime.Enabled = false;
                    textBoxInitialValue.Text = ((DigitalOutput)tag).InitialValue.ToString();
                    comboBoxFunctionType.Enabled = false;
                    break;
                default: disableAll();
                    break;

            }
            comboBoxTagType.Enabled = false;
            textBoxTagId.Enabled = false;

        }


        private void comboBoxTagType_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (comboBoxTagType.SelectedItem.ToString()) {
                case "Analog Input":
                    disableAnalogInput();
                    break;

                case "Analog Output":
                    disableAnalogOutput();
                    break;

                case "Digital Input":
                    disableDigitalInput();
                    break;

                case "Digital Output":
                    disableDigitalOutput();
                    break;

                default: disableAll();
                    break;


            }
        }


        private void disableAll()
        {
            comboBoxFunctionType.Enabled = false;
            textBoxInitialValue.Enabled = true;
            textBoxScanTime.Enabled = false;
            textBoxHighLimit.Enabled = false;
            textBoxLowLimit.Enabled = false;
            textBoxUnits.Enabled = false;
            checkBoxAutoMode.Enabled = false;
            checkBoxOnScan.Enabled = false;
            textBoxDescription.Enabled = false;
            textBoxTagId.Enabled = false;
            textBoxTagAddress.Enabled = false;
        }


        private void disableDigitalOutput()
        {
            comboBoxFunctionType.Enabled = false;
            textBoxInitialValue.Enabled = true;
            textBoxScanTime.Enabled = false;
            textBoxHighLimit.Enabled = false;
            textBoxLowLimit.Enabled = false;
            textBoxUnits.Enabled = false;
            checkBoxAutoMode.Enabled = false;
            checkBoxOnScan.Enabled = false;

            textBoxDescription.Enabled = true;
            textBoxTagId.Enabled = true;
            textBoxTagAddress.Enabled = true;
        }


        private void disableDigitalInput()
        {
            comboBoxFunctionType.Enabled = true;
            textBoxInitialValue.Enabled = false;
            textBoxScanTime.Enabled = true;
            textBoxHighLimit.Enabled = false;
            textBoxLowLimit.Enabled = false;
            textBoxUnits.Enabled = false;
            checkBoxAutoMode.Enabled = true;
            checkBoxOnScan.Enabled = true;

            checkBoxAutoMode.Checked = true;

            textBoxDescription.Enabled = true;
            textBoxTagId.Enabled = true;
            textBoxTagAddress.Enabled = true;
        }


        private void disableAnalogOutput()
        {
            comboBoxFunctionType.Enabled = false;
            textBoxInitialValue.Enabled = true;
            textBoxScanTime.Enabled = false;
            textBoxHighLimit.Enabled = true;
            textBoxLowLimit.Enabled = true;
            textBoxUnits.Enabled = true;
            checkBoxAutoMode.Enabled = false;
            checkBoxOnScan.Enabled = false;

            textBoxDescription.Enabled = true;
            textBoxTagId.Enabled = true;
            textBoxTagAddress.Enabled = true;
        }


        private void disableAnalogInput()
        {
            comboBoxFunctionType.Enabled = true;
            textBoxInitialValue.Enabled = false;
            textBoxScanTime.Enabled = true;
            textBoxHighLimit.Enabled = true;
            textBoxLowLimit.Enabled = true;
            textBoxUnits.Enabled = true;
            checkBoxAutoMode.Enabled = true;
            checkBoxOnScan.Enabled = true;


            checkBoxAutoMode.Checked = true;
            textBoxDescription.Enabled = true;
            textBoxTagId.Enabled = true;
            textBoxTagAddress.Enabled = true;
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            Tag changing = tag;
            if (checkAllInputs()) {
                if (operation.Equals("Add"))
                {
                    changing = createTag();
                    if (!DBManagerForm.proxy.AddTag(changing))
                    {
                        ShowErrorDialog("Tag ID and I/O Address must be unique!");
                        return;
                    }
                    
                }
                else {
                    updateTag();
                    DBManagerForm.proxy.UpdateTag(tag);
                }
                if (changing is InputTag && !((InputTag)changing).Auto)
                {
                    try{
                        DBManagerForm.proxy.ManualSetTagValue((InputTag)changing, double.Parse(textBoxInitialValue.Text));
                    }
                    catch (Exception) { }

                }
                this.DialogResult = DialogResult.OK;
                this.newTag = changing;
                Close();
            }

            else return;
        }


        private void updateTag()
        {
            tag.Description = textBoxDescription.Text;

            switch (tag.GetType().Name) {
                case "AnalogInput":
                    ((AnalogInput)tag).ScanTime = int.Parse(textBoxScanTime.Text);
                    ((AnalogInput)tag).Scan = checkBoxOnScan.Checked;
                    ((AnalogInput)tag).Auto = checkBoxAutoMode.Checked;
                    ((AnalogInput)tag).LowLimit = double.Parse(textBoxLowLimit.Text);
                    ((AnalogInput)tag).HighLimit = double.Parse(textBoxHighLimit.Text);
                    ((AnalogInput)tag).Units = textBoxUnits.Text;
                    ((AnalogInput)tag).Function = comboBoxFunctionType.Text;
                    break;
                case "DigitalInput":
                    ((DigitalInput)tag).ScanTime = int.Parse(textBoxScanTime.Text);
                    ((DigitalInput)tag).Scan = checkBoxOnScan.Checked;
                    ((DigitalInput)tag).Auto = checkBoxAutoMode.Checked;
                    ((DigitalInput)tag).Function = comboBoxFunctionType.Text;
                    break;
                case "AnalogOutput":
                    ((AnalogOutput)tag).InitialValue = double.Parse(textBoxInitialValue.Text);
                    ((AnalogOutput)tag).LowLimit = double.Parse(textBoxLowLimit.Text);
                    ((AnalogOutput)tag).HighLimit = double.Parse(textBoxHighLimit.Text);
                    ((AnalogOutput)tag).Units = textBoxUnits.Text;
                    break;
                case "DigitalOutput":
                    ((DigitalOutput)tag).InitialValue = double.Parse(textBoxInitialValue.Text);
                    break;
            }

        }


        private Tag createTag()
        {
            Tag tag = null;
            switch (comboBoxTagType.SelectedItem.ToString())
            {
                case "Analog Input":
                    tag = new AnalogInput(textBoxTagId.Text, textBoxDescription.Text,
                        textBoxTagAddress.Text, int.Parse(textBoxScanTime.Text),
                        checkBoxOnScan.Checked, checkBoxAutoMode.Checked,
                        double.Parse(textBoxLowLimit.Text), double.Parse(textBoxHighLimit.Text),
                        textBoxUnits.Text, comboBoxFunctionType.Text);
                    break;

                case "Analog Output":
                    tag = new AnalogOutput(textBoxTagId.Text, textBoxDescription.Text,
                        textBoxTagAddress.Text, double.Parse(textBoxInitialValue.Text),
                        double.Parse(textBoxLowLimit.Text),
                        double.Parse(textBoxHighLimit.Text), textBoxUnits.Text);
                    break;

                case "Digital Input":
                    tag = new DigitalInput(textBoxTagId.Text, textBoxDescription.Text,
                        textBoxTagAddress.Text, int.Parse(textBoxScanTime.Text),
                        checkBoxOnScan.Checked, checkBoxAutoMode.Checked,
                        comboBoxFunctionType.Text);
                    break;

                case "Digital Output":
                    tag = new DigitalOutput(textBoxTagId.Text, textBoxDescription.Text,
                        textBoxTagAddress.Text, int.Parse(textBoxInitialValue.Text));
                    break;

            }
            return tag;
        }


        private bool checkAllInputs()
        {
            double num;
            if (string.IsNullOrEmpty(comboBoxTagType.Text))
            {
                ShowErrorDialog("You must select a tag type!");
                return false;
            }
            if (string.IsNullOrEmpty(textBoxTagId.Text) || textBoxTagId.Text.Trim().Equals(""))
            {
                ShowErrorDialog("You must enter an ID!");
                return false;
            }
            if (string.IsNullOrEmpty(textBoxDescription.Text))
            {
                ShowErrorDialog("You must enter a description!");
                return false;
            }
            if (string.IsNullOrEmpty(textBoxTagAddress.Text) || textBoxTagAddress.Text.Trim().Equals(""))
            {
                ShowErrorDialog("You must enter an I/O address!");
                return false;
            }
            if (textBoxInitialValue.Enabled && string.IsNullOrEmpty(textBoxInitialValue.Text))
            {
                ShowErrorDialog("You must enter an initial value!");
                return false;
            }
            if (textBoxInitialValue.Enabled && !double.TryParse(textBoxInitialValue.Text, out num))
            {
                ShowErrorDialog("Initial value must be a number!");
                return false;
            }
            if (comboBoxTagType.SelectedItem.ToString() == "Digital Output" &&
                double.TryParse(textBoxInitialValue.Text, out num) && num != 0 && num != 1)
            {
                ShowErrorDialog("Initial value for digital output tag must be 0 or 1");
                return false;
            }
            if (!checkBoxAutoMode.Checked && comboBoxTagType.SelectedItem.ToString() == "Digital Input" &&
                double.TryParse(textBoxInitialValue.Text, out num) && num != 0 && num != 1)
            {
                ShowErrorDialog("Value for digital input tag must be 0 or 1");
                return false;
            }

            if (textBoxScanTime.Enabled && string.IsNullOrEmpty(textBoxScanTime.Text))
            {
                ShowErrorDialog("You must enter a scan time!");
                return false;
            }
            if (textBoxScanTime.Enabled && !double.TryParse(textBoxScanTime.Text, out num))
            {
                ShowErrorDialog("Scan time must be a number!");
                return false;
            }
            if (textBoxScanTime.Enabled && double.TryParse(textBoxScanTime.Text, out num) && num <= 0)
            {
                ShowErrorDialog("Scan time must be positive!");
                return false;
            }
            if (textBoxLowLimit.Enabled && string.IsNullOrEmpty(textBoxLowLimit.Text))
            {
                ShowErrorDialog("You must enter a low limit!");
                return false;
            }
            if (textBoxLowLimit.Enabled && !double.TryParse(textBoxLowLimit.Text, out num))
            {
                ShowErrorDialog("Low limit must be a number!");
                return false;
            }
            if (textBoxHighLimit.Enabled && string.IsNullOrEmpty(textBoxHighLimit.Text))
            {
                ShowErrorDialog("You must enter a high limit!");
                return false;
            }
            if (textBoxHighLimit.Enabled && !double.TryParse(textBoxHighLimit.Text, out num))
            {
                ShowErrorDialog("High limit must be a number!");
                return false;
            }
            if (textBoxUnits.Enabled && string.IsNullOrEmpty(textBoxUnits.Text))
            {
                ShowErrorDialog("You must enter a unit type!");
                return false;
            }
            if (comboBoxTagType.SelectedItem.ToString() == "Digital Input" &&
                double.TryParse(textBoxInitialValue.Text, out num) && num != 0 && num != 1)
            {
                ShowErrorDialog("Value for digital input tag must be 0 or 1");
                return false;
            }
            if (comboBoxFunctionType.Enabled && string.IsNullOrEmpty(comboBoxFunctionType.Text))
            {
                ShowErrorDialog("You must choose a function type!");
                return false;
            }
            if (!checkBoxAutoMode.Checked && (comboBoxTagType.SelectedItem.ToString() == "Analog Input" 
                || comboBoxTagType.SelectedItem.ToString() == "Analog Output") &&
                double.TryParse(textBoxInitialValue.Text, out num) &&
                (num < double.Parse(textBoxLowLimit.Text) || num > double.Parse(textBoxHighLimit.Text)))
            {
                ShowErrorDialog("Value must be between high and low limit!");
                return false;
            }
            return true;
        }


        private void ShowErrorDialog(string v)
        {
            MessageBox.Show(v, "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }


        private void checkBoxAutoMode_CheckedChanged(object sender, EventArgs e)
        {
            textBoxInitialValue.Enabled = true;
            if (checkBoxAutoMode.Checked) textBoxInitialValue.Enabled = false;
        }


        public Tag NewTag
        {
            get { return newTag; }
            set { newTag = value; }
        }
    }
}
