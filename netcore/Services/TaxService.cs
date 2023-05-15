using congestion.calculator.Dto;
using congestion.calculator.Interfaces;
using Dto.UseCases.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace congestion.calculator.Services
{
    public abstract class TaxService
    {
        private DateTime _intervalStart { get; }
        private bool _freeTax { get; }
        private readonly IConfiguration _configuration;
        public TaxService(IConfiguration configuration) {
            _intervalStart = request.Dates[0];
            _freeTax = request.Vehicle.FreeTax();
            _configuration = configuration;
        }
        public void init()
        {
            GetTaxRequestDtoUseCase request,
        }
        


        public bool CheckFreeVehicle()
        {
            return _freeTax;
        }
        public virtual bool CheckCalendarToFreeTollFee(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;
          
            return _configuration.GetCalendar().Where(i => i._DateTime ==date ).FirstOrDefault()?.IsFreeTollFee ?? false;

        }
        public DateTime GetIntervalStart()
        {
            return _intervalStart;
        }
        public virtual int GetTollFee(DateTime date)
        {
            var IsFreeTollFee = CheckCalendarToFreeTollFee(date);

            if (!_freeTax && !IsFreeTollFee)
            {
                var currentTime = TimeOnly.FromDateTime(date);
                return _configuration.GetTollFee().Where(i=> i.Start <= currentTime && i.End >= currentTime).FirstOrDefault()?.Fee??0;
            }

            return 0;
        }
    }
}
