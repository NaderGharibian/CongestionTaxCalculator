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
    public abstract class TaxAbstract
    {
        private DateTime[] _dates { get; }
        private bool _freeTax { get; }
        private readonly IConfiguration _configuration;
        public TaxAbstract(GetTaxRequestDtoUseCase request,IConfiguration configuration) {
            _dates = request.Dates;
            _freeTax = request.Vehicle.FreeTax();
            _configuration = configuration;
        }


        public bool CheckFreeVehicle()
        {
            return _freeTax;
        }
        public virtual bool CheckCalendarToFreeTollFee(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;
          
            return _configuration.GetCalendar().Where(i => i._DateTime == date ).FirstOrDefault()?.IsFreeTollFee ?? false;

        }
        public DateTime GetFirstDate()
        {
            return _dates[0];
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
        public virtual int Calculate()
        {
            if (CheckFreeVehicle())
            {
                int totalFee = 0;
                DateTime intervalStart = GetFirstDate();
                int tempFee = GetTollFee(intervalStart); 
           

                foreach (DateTime date in _dates)
                {
                    int nextFee = GetTollFee(date);


                    long diffInMillies = date.Millisecond - intervalStart.Millisecond;
                    long minutes = diffInMillies / 1000 / 60;

                    if (minutes <= 60)
                    {
                        if (totalFee > 0) totalFee -= tempFee;
                        if (nextFee >= tempFee) tempFee = nextFee;
                        totalFee += tempFee;
                    }
                    else
                    {
                        totalFee += nextFee;
                    }
                }
                if (totalFee > 60) totalFee = 60;
                return totalFee;
            }
            return 0;
        }
    }
}
