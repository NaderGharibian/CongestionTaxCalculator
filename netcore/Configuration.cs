using congestion.calculator.Dto;
using congestion.calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace congestion.calculator
{
    internal class Configuration: IConfiguration
    {
        public Configuration() { }

        private List<TollFeeContent> _tollFeeContents { get; set; }
        private List<DateTimeContent> _dateTimeContents { get; set; }
        private DateOnly[] _holidays { get; set; }

        public void SetTollFee(List<TollFeeContent> tollFeeContents)
        {
            _tollFeeContents = tollFeeContents;
        }
        public List<TollFeeContent> GetTollFee()
        {
            return _tollFeeContents;
        }

        public void SetCalendar(DateOnly from, DateOnly to,DateOnly[] holiday)
        {
            _dateTimeContents = new();
            _holidays = holiday;
            for (var day = from; day <= to; day = day.AddDays(1))
            {   
               var isHoliday =  holiday?.FirstOrDefault(i=> i==day)!=null?true:false;
                _dateTimeContents.Add(new DateTimeContent(_date: day, isHoliday: isHoliday));
            }
           
        }
        public DateOnly[] GetHoliday()
        {
            return _holidays;
        }
        public List<DateTimeContent> GetCalendar()
        {
            return _dateTimeContents;
        }


    }
}
