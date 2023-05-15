using System;

namespace congestion.calculator.Dto
{
    public class TollFeeContent
    {
        public TimeOnly Start { get; set; }
        public TimeOnly End { get; set; }
        public int Fee { get; set; }
        public TollFeeContent(TimeOnly start, TimeOnly end,int fee ) { 
            this.Start = start;
            this.End = end; 
            this.Fee = fee;
        }

    }
    
}
