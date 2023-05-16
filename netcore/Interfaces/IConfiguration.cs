using congestion.calculator.Dto;

using System;
using System.Collections.Generic;

namespace congestion.calculator.Interfaces;

public interface IConfiguration
{
    void SetTollFee(List<TollFeeContent> tollFeeContents);
    List<TollFeeContent> GetTollFee();
    void SetCalendar(DateOnly from, DateOnly to, DateOnly[] holiday);
    List<DateTimeContent> GetCalendar();
    DateOnly[] GetHoliday();
    }