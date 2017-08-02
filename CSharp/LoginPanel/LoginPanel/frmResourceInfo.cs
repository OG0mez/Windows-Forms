/* 
 * Programmer: Hunter Johnson
 * Name: Resource Information
 * Info: Allows you to view different types of information about your Computer. Ex: Graphics, USB Controllers, System Info, Account and Security, etc.
 * Class: CIS 153-01

 * Computer System Hardware Classes list I used as keys https://msdn.microsoft.com/en-us/library/aa389273.aspx  
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;


namespace LoginPanel
{
    public partial class frmResourceInfo : Form
    {
        public frmResourceInfo()
        {
            InitializeComponent();
            hardwareComboBox.SelectedItem = "Win32_Processor";
        }
        private void DeleteNullValues(ref ListView listView)
        {
            // iterate through the items and remove the ones that are null
            foreach (ListViewItem item in listView.Items)
                if (item.SubItems[1].Text == "No Information available")
                    item.Remove();
        }

        private void InsertData(string Key, ref ListView listView, bool nullValues)
        {
            // clear the listview
            listView.Items.Clear();

            // create ManagementObjectSearcher object
            // retrieves a collection of management objects based on the query
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + Key);

            try
            {
                // get() - executes the given query in the specified scope and returns a collection of management objects that match the query in a ManagementObjectCollection
                foreach (ManagementObject share in searcher.Get()) // WMI instance
                {
                    // create ListViewGroup object
                    ListViewGroup listViewGroup;
                    try
                    {
                        // gets collection of listView objects assigned to control
                        listViewGroup = listView.Groups.Add(share["Name"].ToString(), share["Name"].ToString()); 
                    }
                    catch
                    {
                        // gets collection of listView objects assigned to control
                        listViewGroup = listView.Groups.Add(share.ToString(), share.ToString());
                    }

                    if (share.Properties.Count <= 0) // objects properties are empty
                    {
                        MessageBox.Show("No Information Available", "Empty Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    foreach (PropertyData property in share.Properties)
                    {
                        // create ListViewItem object
                        ListViewItem listViewItem = new ListViewItem(listViewGroup);
                      
                        if (listView.Items.Count % 2 != 0)
                            listViewItem.BackColor = Color.White;
                        else
                            listViewItem.BackColor = Color.WhiteSmoke;

                        listViewItem.Text = property.Name;

                        // if information exists
                        if (property.Value != null && property.Value.ToString() != "")
                        {
                            switch (property.Value.GetType().ToString())
                            {
                                case "System.String[]":
                                    {
                                        string[] str = (string[])property.Value;
                                        string str2 = "";
                                        // Adds the strings together from the property and stories them as SubItems of the listview
                                        foreach (string st in str)
                                        {
                                            str2 += st + " ";
                                        }
                                        listViewItem.SubItems.Add(str2);
                                        break;
                                    }
                                case "System.UInt16[]":
                                    {
                                        ushort[] shortData = (ushort[])property.Value;
                                        string tstr2 = "";
                                        foreach (ushort st in shortData)
                                        {
                                            tstr2 += st.ToString() + " ";
                                        }
                                        listViewItem.SubItems.Add(tstr2);                                   
                                        break;
                                    }

                                default:
                                    {
                                        listViewItem.SubItems.Add(property.Value.ToString());
                                        break;
                                    }
                            }
                        }
                        // no info exists
                        else
                        {
                            if (!nullValues)
                                listViewItem.SubItems.Add("No Information available");
                            else
                                continue;
                        }
                        // add the item to the listview
                        listView.Items.Add(listViewItem);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmResourceInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void cmbxHardware_SelectedIndexChanged(object sender, EventArgs e)
        {
            // call the InsertData method to fill data in hardwareInfoListView
            InsertData(hardwareComboBox.SelectedItem.ToString(), ref hardwareInfoListView, hardwareCheckbox.Checked);
        }

        private void systemInfoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // call the InsertData method to fill data in systemInfoListView
            InsertData(systemInfoComboBox.SelectedItem.ToString(), ref systemInfoListView, systemInfoCheckbox.Checked);
        }

        private void developerInfoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // call the InsertData method to fill data in developerInfoListView
            InsertData(developerInfoComboBox.SelectedItem.ToString(), ref developerInfoListView, developerInfoCheckbox.Checked);
        }

        private void networkComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // call the InsertData method to fill data in networkListView
            InsertData(networkComboBox.SelectedItem.ToString(), ref networkListView, networkCheckbox.Checked);
        }

        private void storageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // call the InsertData method to fill data in storageListView
            InsertData(storageComboBox.SelectedItem.ToString(), ref storageListView, storageCheckbox.Checked);
        }

        private void memoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // call the InsertData method to fill data in memoryListView
            InsertData(memoryComboBox.SelectedItem.ToString(), ref memoryListView, memoryCheckbox.Checked);
        }

        private void utilityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // call the InsertData method to fill data in utilityListView
            InsertData(utilityComboBox.SelectedItem.ToString(), ref utilityListView, utilityCheckbox.Checked);
        }

        private void accountComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // call the InsertData method to fill data in accountListView
            InsertData(accountComboBox.SelectedItem.ToString(), ref accountListView, accountCheckbox.Checked);
        }


        /*
         * The code from here and below determines whether the Null Value checkbox has been checked - Deletes null values if it's checked.
         * It also has Click events for the Arrow PictureBoxes to allow for navigation of the tabs
         */
        private void hardwareCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (hardwareCheckbox.Checked)
                DeleteNullValues(ref hardwareInfoListView);
            else
                InsertData(hardwareComboBox.SelectedItem.ToString(), ref systemInfoListView, false);
        }

        private void systemInfoCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (systemInfoCheckbox.Checked)
                DeleteNullValues(ref systemInfoListView);
            else
                InsertData(systemInfoComboBox.SelectedItem.ToString(), ref systemInfoListView, false);
        }

        private void memoryCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (memoryCheckbox.Checked)
                DeleteNullValues(ref memoryListView);
            else
                InsertData(memoryComboBox.SelectedItem.ToString(), ref memoryListView, false);
        }

        private void storageCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (storageCheckbox.Checked)
                DeleteNullValues(ref storageListView);
            else
                InsertData(storageComboBox.SelectedItem.ToString(), ref storageListView, false);
        }

        private void networkCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (networkCheckbox.Checked)
                DeleteNullValues(ref networkListView);
            else
                InsertData(networkComboBox.SelectedItem.ToString(), ref networkListView, false);           
        }

        private void developerInfoCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (developerInfoCheckbox.Checked)
                DeleteNullValues(ref developerInfoListView);
            else
                InsertData(developerInfoComboBox.SelectedItem.ToString(), ref developerInfoListView, false);        
        }

        private void utilityCheckbox_CheckedChanged(object sender, EventArgs e)
        {

            if (utilityCheckbox.Checked)
                DeleteNullValues(ref utilityListView);
            else
                InsertData(utilityComboBox.SelectedItem.ToString(), ref utilityListView, false);
        }

        private void accountCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (accountCheckbox.Checked)
                DeleteNullValues(ref accountListView);
            else
                InsertData(accountComboBox.SelectedItem.ToString(), ref accountListView, false);
        }

        private void hardwareNextPicBox_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex += 1;
        }

        private void systemInfoBackPicBox_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex -= 1;
        }

        private void systemInfoNextPicBox_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex += 1;
        }

        private void memoryNextPicBox_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex += 1;
        }

        private void memoryBackPicBox_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex -= 1;
        }

        private void storageBackPicBox_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex -= 1;
        }

        private void storageNextPicBox_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex += 1;
        }

        private void networkBackPicBox_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex -= 1;
        }

        private void networkNextPicBox_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex += 1;
        }

        private void devInfoNextPicBox_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex += 1;
        }

        private void devInfoBackPicBox_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex -= 1;
        }

        private void utilInfoBackPicBox_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex -= 1;
        }

        private void utilityInfoNextPicBox_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex += 1;
        }

        private void accountBackPicBox_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex -= 1;
        }

    }
}
