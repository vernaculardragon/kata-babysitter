using System;
using BabySitter.BL;
using Common.Contracts.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalcTest
{
    [TestClass]
    public class CalcuatePayment
    {
        [TestMethod]
        public void GeneralTest()
        {
            var Payment = new Payment
            {
                StartDateTime = DateTime.Now.Date.AddHours(17),
                BedTime = DateTime.Now.Date.AddHours(20),
                EndDateTime = DateTime.Now.Date.AddDays(1).AddHours(4)
            };

            var paymentBL = new PaymentBL();
            var final = paymentBL.CalcAmountOwed(Payment);

           // 3hrs pre bed - 3*12 = 36
           //4hours post bed 4*8 = 32
            //4 hours post midnight 4*16 = 64


            // total money = 132
            Assert.IsTrue(final.AmountOwed == 132);

        }
    }
}
