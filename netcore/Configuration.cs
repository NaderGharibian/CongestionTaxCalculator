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

        public void SetTollFee(List<TollFeeContent> tollFeeContents)
        {
            tollFeeContents.AddRange(this._tollFeeContents);
        }
        public List<TollFeeContent> GetTollFee()
        {
            return _tollFeeContents;
        }
    }
}
