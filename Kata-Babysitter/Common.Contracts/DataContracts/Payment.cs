using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts.DataContracts
{
    public class Payment
    {
        public DateTime StartDateTime { get; set; }

        public DateTime BedTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public decimal AmountOwed { get; set; }
    }
}
