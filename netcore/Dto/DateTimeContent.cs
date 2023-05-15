using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace congestion.calculator.Dto
{
    public class DateTimeContent
    {
        public DateTime _DateTime { get; }
        public bool IsFreeTollFee { get; set; }
        public DateTimeContent(DateTime _dateTime, bool isFreeTollFee)
        {
            _DateTime = _dateTime;
            IsFreeTollFee = isFreeTollFee;
        }

    }
}
