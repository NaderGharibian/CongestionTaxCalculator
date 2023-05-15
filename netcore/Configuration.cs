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

        public void SetTollFee(List<TollFeeContent> tollFeeContents)
        {
            _tollFeeContents.AddRange(tollFeeContents);
        }
        public List<TollFeeContent> GetTollFee()
        {
            return _tollFeeContents;
        }

        public void SetCalendar(List<DateTimeContent> dateTimeContents)
        {
            _dateTimeContents.AddRange(dateTimeContents);
        }
        public List<DateTimeContent> GetCalendar()
        {
            return _dateTimeContents;
        }


    }
}
