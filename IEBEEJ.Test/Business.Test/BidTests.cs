using IEBEEJ.Business.Models;
using IEBEEJ.Business.Services;
using IEBEEJ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEBEEJ.Test.Business.Test
{
    internal class BidTests
    {
        [Test]
        public void WhenBidIsCreated_ItHasACorrectValue()
        {
            //Arange
            BidEntity bid = new BidEntity();
            decimal expectedValue = 500;
            bid.BidValue = 500;
            BidService service = new BidService();
            //Act
            service.CreateABidAsync(500, 1, 1);
            //Assert
            Assert.That(bid.BidValue, Is.EqualTo(expectedValue));
        }
    }
}
