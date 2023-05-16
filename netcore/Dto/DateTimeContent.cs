using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace congestion.calculator.Dto
{
    public class DateTimeContent
    {
        public DateOnly _Date { get; }
        public bool IsHoliday { get; set; }
        public DateTimeContent(DateOnly _date, bool isHoliday)
        {
            _Date = _date;
            IsHoliday = isHoliday;
        }

    }
}
