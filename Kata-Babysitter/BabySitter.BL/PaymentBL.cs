using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Contracts;
using Common.Contracts.DataContracts;

namespace BabySitter.BL
{
    public class PaymentBL
    {
        private DateTime _bedTime;
        private DateTime _ShiftDate;

      
        public Payment CalcAmountOwed(Payment Hours)
        {
            _bedTime = Hours.BedTime.Value;
            _ShiftDate = Hours.BedTime.Value.Date;
            decimal Owed = 0;
            var ShiftTime = Hours.StartDateTime;

            while (ShiftTime < Hours.EndDateTime)
            {
                var endTime = GetShiftEnd(ShiftTime.Value, Hours.EndDateTime.Value);
                Owed += GetShiftAmount(ShiftTime.Value, endTime, GetShiftRate(ShiftTime.Value));
                ShiftTime = endTime;
            }
            Hours.AmountOwed = Owed;
            return Hours;

        }

        private DateTime GetShiftEnd(DateTime ShiftStart, DateTime FinalEnd)
        {

            if (ShiftStart < _bedTime)
            {
                return _bedTime;
            }
            else if (ShiftStart < _ShiftDate.AddDays(1).Date && FinalEnd > _ShiftDate.AddDays(1).Date)
            {
                return _ShiftDate.AddDays(1).Date;
            }
            else
            {
                return FinalEnd;
            }

        }

        private decimal GetShiftRate(DateTime ShiftStart)
        {
            if (ShiftStart < _bedTime)
            {
                return Constants.PreBedRate;
            }else if(ShiftStart < _ShiftDate.AddDays(1).Date)
            {
                return Constants.PostBedRate;
            }
            else
            {
                return Constants.PostMidnightRate;
            }

        }

        private decimal GetShiftAmount(DateTime ShiftStart, DateTime ShiftEnd, decimal ShiftRate)
        {
            var ShiftTime =(int) Math.Ceiling((ShiftEnd-ShiftStart).TotalMinutes/60);
            var Owed = ShiftRate * ShiftTime;
            return Owed;

        }


    }
}
