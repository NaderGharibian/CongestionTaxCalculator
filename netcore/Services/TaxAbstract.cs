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
        public TaxAbstract(GetTaxRequestDtoUseCase request, IConfiguration configuration)
        {
            _dates = request.Dates.OrderBy(_ => _.Date).ToArray();
            _freeTax = request.Vehicle.FreeTax();
            _configuration = configuration;
        }


        public bool CheckFreeVehicle()
        {
            return _freeTax;
        }
        public virtual bool CheckCalendarToFreeTollFee(DateOnly date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;

            return _configuration.GetHoliday().Where(i => i == date).Count() > 0 ? true : false;

        }
        public DateTime GetFirstDate()
        {
            return _dates[0];
        }
        public List<DateOnly> GetGroupDate()
        {
            return _dates.GroupBy(_ => _.Date).Select(_ => DateOnly.FromDateTime(_.Key)).OrderBy(_ => _).ToList();
        }
        public List<DateTime> GetDates(DateOnly date)
        {
            return _dates.Where(_ => DateOnly.FromDateTime(_.Date) == date).OrderBy(_ => _).ToList();
        }
        public virtual int GetTollFee(DateTime date)
        {
            var IsFreeTollFee = CheckCalendarToFreeTollFee(DateOnly.FromDateTime(date));

            if (!_freeTax && !IsFreeTollFee)
            {
                var currentTime = TimeOnly.FromDateTime(date);
                return _configuration.GetTollFee().Where(i => i.Start <= currentTime && i.End >= currentTime).FirstOrDefault()?.Fee ?? 0;
            }

            return 0;
        }
        public virtual int Calculate()
        {
            if (CheckFreeVehicle())
                return 0;

            int totalFee = 0;
            foreach (var date in GetGroupDate())
            {


                var getList = GetDates(date);
                DateTime from = getList[0];
                List<int> listFee = new();
                int tempFee = 0;






                foreach (var datetime in getList)
                {

                    TimeSpan diffInMillies = datetime - from;
                    var minutes = diffInMillies.TotalMinutes;
                    int fee = GetTollFee(datetime);

                    if (minutes >= 60)
                    {
                        if (listFee.Count > 0)
                        {
                            tempFee += listFee[listFee.Count - 1];
                            listFee = new();
                        }
                        from = datetime;

                    }
                    listFee.Add(fee);
                }

                if (listFee.Count > 0)
                {
                    tempFee += listFee.Sum(_ => _);
                }

                if (tempFee > 0)
                    totalFee += (tempFee > 60) ? 60 : tempFee;



            }
            //foreach (DateTime date in _dates)
            //{
            //    int nextFee = GetTollFee(date);





            //}
            //if (totalFee > 60) totalFee = 60;
            return totalFee;

        }
    }
}
