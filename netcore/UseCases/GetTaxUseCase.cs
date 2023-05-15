using Dto.Enums.Message;
using Dto.Enums;
using Dto.UseCases.Requests;
using Dto.UseCases.Responses;
using Helpers;
using Interfaces;
using System;
using System.Threading.Tasks;
using congestion.calculator.Services;

namespace congestion.calculator.UseCases
{
    internal class GetTaxUseCase : IGetTaxUseCase
    {   /**
         * Calculate the total toll fee for one day
         *
         * @param vehicle - the vehicle
         * @param dates   - date and time of all passes on one day
         * @return - the total congestion tax for that day
         */

        public async Task<bool> Handle(GetTaxRequestDtoUseCase request, IResponseUseCase<GetTaxResponseDtoUseCase> response)
        {
            if (request.Vehicle == null)
            {
                response.Handle(new GetTaxResponseDtoUseCase(StatusCode.Failed, new ResponseMessage("The Vehicle should not be empty")));
                return false;
            }
            int totalFee = 0;
            var tax = new TaxService(request);


            if(!tax.CheckFreeVehicle())
            {

                DateTime intervalStart = request.Dates[0];
                int tempFee = GetTollFee(intervalStart, request.Vehicle);



                foreach (DateTime date in request.Dates)
                {
                    int nextFee = GetTollFee(date, request.Vehicle);


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
            }


           


            response.Handle(new GetTaxResponseDtoUseCase(totalFee, StatusCode.Successed, new(EnumHelper<Success>.GetDisplayValue(Success.SUCCESSFULLY_COMPLETED))));
        }
        private bool IsTollFreeVehicle(Vehicle vehicle)
        {
           
            String vehicleType = vehicle.GetVehicleType();
            return vehicleType.Equals(TollFreeVehicles.Motorcycle.ToString()) ||
                   vehicleType.Equals(TollFreeVehicles.Tractor.ToString()) ||
                   vehicleType.Equals(TollFreeVehicles.Emergency.ToString()) ||
                   vehicleType.Equals(TollFreeVehicles.Diplomat.ToString()) ||
                   vehicleType.Equals(TollFreeVehicles.Foreign.ToString()) ||
                   vehicleType.Equals(TollFreeVehicles.Military.ToString());
        }

        public int GetTollFee(DateTime date, Vehicle vehicle)
        {
            if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle)) return 0;

            int hour = date.Hour;
            int minute = date.Minute;

            if (hour == 6 && minute >= 0 && minute <= 29) return 8;
            else if (hour == 6 && minute >= 30 && minute <= 59) return 13;
            else if (hour == 7 && minute >= 0 && minute <= 59) return 18;
            else if (hour == 8 && minute >= 0 && minute <= 29) return 13;
            else if (hour >= 8 && hour <= 14 && minute >= 30 && minute <= 59) return 8;
            else if (hour == 15 && minute >= 0 && minute <= 29) return 13;
            else if (hour == 15 && minute >= 0 || hour == 16 && minute <= 59) return 18;
            else if (hour == 17 && minute >= 0 && minute <= 59) return 13;
            else if (hour == 18 && minute >= 0 && minute <= 29) return 8;
            else return 0;
        }

        private Boolean IsTollFreeDate(DateTime date)
        {
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;

            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;

            if (year == 2013)
            {
                if (month == 1 && day == 1 ||
                    month == 3 && (day == 28 || day == 29) ||
                    month == 4 && (day == 1 || day == 30) ||
                    month == 5 && (day == 1 || day == 8 || day == 9) ||
                    month == 6 && (day == 5 || day == 6 || day == 21) ||
                    month == 7 ||
                    month == 11 && day == 1 ||
                    month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
