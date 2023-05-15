using congestion.calculator.Dto;
using System.Collections.Generic;

namespace congestion.calculator.Interfaces;

public interface IConfiguration
{
    void SetTollFee(List<TollFeeContent> tollFeeContents);
    List<TollFeeContent> GetTollFee();
    void SetCalendar(List<DateTimeContent> dateTimeContents);
    List<DateTimeContent> GetCalendar();
    }