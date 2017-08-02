/*
 * Programmer: Hunter Johnson
 * Name: Employee and Production Worker Classes Pg.643(1)
 * Info: Create classes for each, and create an object of the ProductionWorker class. Let user enter data.
 * Class: CIS 153 - Desktop App Development  
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

namespace EmployeeAndProductionWorker_Pg._643_1__
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // close the form
            this.Close();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            // variables to hold input
            string shift;
            int shiftNumber;

            // Create ProductionWorker object
            ProductionWorker myEmployee = new ProductionWorker();

            // access the properties of the base class and store the input
            myEmployee.Name = nameTextBox.Text;
            myEmployee.EmployeeNumber = int.Parse(employeeNumberTextBox.Text);
            myEmployee.HourlyPayRate = double.Parse(hourlyPayRateTextBox.Text);
            // validate the shiftnumber input
            if (int.TryParse(shiftNumberTextBox.Text, out shiftNumber))
            {
                myEmployee.ShiftNumber = shiftNumber;
            }
            else
            {
                // display error message
                MessageBox.Show("Invalid Shift Input");
            }

            // determine the shift worked
            if(myEmployee.ShiftNumber == 1)
            {
                shift = "Day Shift";
            }
            else
            {
                shift = "Night Shift";
            }

            // retrieve the objects properties and display their values
            nameLabel.Text = myEmployee.Name.ToString();
            employeeNumberLabel.Text = myEmployee.EmployeeNumber.ToString();
            shiftLabel.Text = shift.ToString();
            payRateLabel.Text = myEmployee.HourlyPayRate.ToString("C2") + "/hr";
        }
    }
}
