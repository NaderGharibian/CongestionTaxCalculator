using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace congestion.calculator
{
    public class Car : Vehicle
    {
        public bool FreeTax()
        {
            return false;
        }

        public String GetVehicleType()
        {
            return "Car";
        }
    }
}