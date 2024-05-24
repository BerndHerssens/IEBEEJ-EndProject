using AutoMapper;
using IEBEEJ.Business.Models;
using IEBEEJ.Business.Services;
using IEBEEJ.Configuration;
using IEBEEJ.Data.Entities;
using IEBEEJ.Data.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEBEEJ.Test.Business.Test
{
    internal class BidServiceTests
    {
        [Test]
        public async Task CreateABidAsync_ShouldCreateBid()
        {
            // Arrange
            var config = new MapperConfiguration(x => x.AddProfile(new IEBEEJProfile()));
            var mapper = config.CreateMapper();

            decimal value = 100;
            int bidderID = 1;
            int itemID = 1;
            Item item = new Item();

            var bidRepositoryMock = new Mock<IBidRepository>();
            var bidService = new BidService(bidRepositoryMock.Object, mapper);

            // Act
            await bidService.CreateABidAsync(value, bidderID, item);

            // Assert
            bidRepositoryMock.Verify(repo => repo.CreateBidAsync(It.Is<BidEntity>(bid =>
                bid.BidValue == value &&
                bid.IsActive &&
                bid.BidderId == bidderID &&
                bid.ItemID == itemID &&
                bid.Created.Date == DateTime.Now.Date
            )), Times.Once);
        }

        [Test]
        public void WhenAnItemHasMultipleBids_ThenHighestBidIsActive()
        {
            //Arrange
            var config = new MapperConfiguration(x => x.AddProfile(new IEBEEJProfile()));
            var mapper = config.CreateMapper();
            Item item = new Item();
            item.ItemName = "Chinese Antieke Vaas";
            item.Id = 1;
            var bid1 = new Bid(1, 800, 1);
            var bid2 = new Bid(3, 3500, 1);
            var bid3 = new Bid(3, 200, 1);
            List<Bid> bidList = new List<Bid>();
            bidList.Add(bid1);
            bidList.Add(bid2);
            bidList.Add(bid3);
            item.AllBids = bidList;
            decimal expectedvalue = 3500;
            
            var itemRepositoryMock = new Mock<IItemRepository>();
            ItemService itemService = new ItemService(itemRepositoryMock.Object, mapper);

            //Act

            itemService.GetHighestBidOnItem(item);

            //Assert
            Assert.AreEqual(item.HighestBid.BidValue, expectedvalue);
        }
    }
}
