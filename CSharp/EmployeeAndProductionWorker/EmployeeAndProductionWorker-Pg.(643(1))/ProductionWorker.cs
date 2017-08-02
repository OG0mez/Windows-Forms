using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAndProductionWorker_Pg._643_1__
{
    class ProductionWorker : Employee // Means that ProductionWorker is derived from the Employee derived class
    {
        // fields
        private int _shiftNumber; // 1 is day shift, 2 is night shift
        private double _hourlyPayRate;

        // constructor
        public ProductionWorker()
        {
            _shiftNumber = 0;
            _hourlyPayRate = 0;
        }

        // ShiftNumber property
        public int ShiftNumber
        {
            get { return _shiftNumber; }
            set { _shiftNumber = value; }
        }

        // HourlyPayRate property
        public double HourlyPayRate
        {
            get { return _hourlyPayRate; }
            set { _hourlyPayRate = value; }
        }  
    }
}
