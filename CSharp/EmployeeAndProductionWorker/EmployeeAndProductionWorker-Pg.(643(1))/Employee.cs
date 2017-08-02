using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAndProductionWorker_Pg._643_1__
{
    class Employee
    {
        // Fields
        private string _name;
        private int _employeeNumber;

        // Constructor
        public Employee()
        {
            _name = "";
            _employeeNumber = 0;
        }

        // Name property
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // EmployeeNumber property
        public int EmployeeNumber
        {
            get { return _employeeNumber; }
            set { _employeeNumber = value; }
        }
    }
}
