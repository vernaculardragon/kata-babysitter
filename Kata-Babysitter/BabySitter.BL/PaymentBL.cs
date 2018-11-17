﻿using System;
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
        public PaymentBL(DateTime BedTime)
        {
            _bedTime = BedTime;
            _ShiftDate = BedTime.Date;

        }
        public Payment CalcAmountOwed(Payment Hours)
        {
            decimal Owed = 0;
            var ShiftTime = Hours.StartDateTime;

            while (ShiftTime < Hours.EndDateTime)
            {
                var endTime = GetShiftEnd(ShiftTime, Hours.EndDateTime);
                Owed += GetShiftAmount(ShiftTime, endTime, GetShiftRate(ShiftTime));
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
            else if (ShiftStart < _ShiftDate.AddDays(1).Date)
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
            var ShiftTime = ( ShiftEnd-ShiftStart).Hours;
            var Owed = ShiftRate * ShiftTime;
            return Owed;

        }


    }
}
