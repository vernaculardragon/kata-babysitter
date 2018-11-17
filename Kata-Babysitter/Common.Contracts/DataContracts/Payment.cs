using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts.DataContracts
{
    public class Payment
    {
        [Required]
        [UIHint("Time")]
        [Display(Name = "Start Time")]
        public DateTime? StartDateTime { get; set; }
        [UIHint("Time")]
        [Required]
        [Display(Name = "Bed Time")]
        public DateTime? BedTime { get; set; }
        [UIHint("Time")]
        [Required]
        [Display(Name = "End Time")]
        public DateTime? EndDateTime { get; set; }

        public decimal AmountOwed { get; set; }

        public DateTime EarliestStart
        {
            get { return StartDateTime.Value.Date.AddHours(17); }
        }
        public DateTime LatestLeave
        {
            get { return StartDateTime.Value.Date.AddDays(1).AddHours(4); }
        }
        public DateTime Midnight
        {
            get { return StartDateTime.Value.Date.AddDays(1); }
        }
        public List<ValidationError> Validate()
        {
            var Errors = new List<ValidationError>();

            if (StartDateTime < EarliestStart)
            {
                Errors.Add(new ValidationError(nameof(StartDateTime), $"Start Time cannot be Earlier than {EarliestStart}"));
            }
            if (EndDateTime > LatestLeave)
            {
                Errors.Add(new ValidationError(nameof(EndDateTime), $"End Time cannot be Later than {LatestLeave}"));
            }
            if (StartDateTime > BedTime)
            {
                Errors.Add(new ValidationError(nameof(BedTime), $"Bed Time cannot be Earlier than Start Time"));
            }
            if (BedTime > EndDateTime)
            {
                Errors.Add(new ValidationError(nameof(BedTime), $"Bed Time cannot be Later than End Time"));
            }
            if (BedTime > Midnight)
            {
                Errors.Add(new ValidationError(nameof(BedTime), $"Bed Time cannot be Later than Midnight"));
            }
            if (EndDateTime <= StartDateTime)
            {
                Errors.Add(new ValidationError(nameof(EndDateTime), $"End Time cannot be Earlier than Start Time"));
            }

            return Errors;
        }

    }
}
