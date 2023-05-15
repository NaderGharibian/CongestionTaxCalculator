using Dto.UseCases.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace congestion.calculator.Services
{
    internal class TaxService
    {
        private DateTime _intervalStart { get; }
        private bool _freeTax { get; }
        public TaxService(GetTaxRequestDtoUseCase request) {
            _intervalStart = request.Dates[0];
            _freeTax = request.Vehicle.FreeTax();
        }


        public bool CheckFreeVehicle()
        {
            return _freeTax;
        }
        public DateTime GetIntervalStart()
        {
            return _intervalStart;
        }
        public int GetTollFee()
        {

        }
    }
}
