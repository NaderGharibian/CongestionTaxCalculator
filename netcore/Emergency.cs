using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace congestion.calculator
{
    public class Emergency : Vehicle
    {
        public bool FreeTax()
        {
            return true;
        }
        public String GetVehicleType()
        {
            return "Emergency";
        }
    }
}