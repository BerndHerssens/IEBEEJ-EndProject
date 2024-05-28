using AutoMapper;
using IEBEEJ.Business.Models;
using IEBEEJ.Business.Services;
using IEBEEJ.DTOs.BidDTOs;
using IEBEEJ.DTOs.ItemDTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IEBEEJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidController : ControllerBase
    {
        private IMapper _mapper;
        private IBidService _bidService;
        public BidController(IMapper mapper, IBidService bidService)
        {
            _mapper = mapper;
            _bidService = bidService;
        }

        // GET: api/<BidController>
        [HttpGet]
        [Route("GetAllBidsByItemId/{itemId:int}")]
        public async Task<ActionResult<IEnumerable<Bid>>> GetAllBidsByItemId(int itemId)
        {
            IEnumerable<Bid> bids = await _bidService.GetAllBidsByItemIDAsync(itemId);

            return Ok(bids);
        }


        // GET api/<BidController>/5

        [HttpGet]
        [Route("GetBidById/{id:int}")]
        public async Task<ActionResult<Bid>> GetBidById(int id)
        {
            Bid bid = await _bidService.GetBidByIdAsync(id);

            return Ok(bid);
        }
        

        // POST api/<BidController>
        [HttpPost]
        public async Task<ActionResult> Post(AddBidDTO bidDTO)
        {
            Bid bid = _mapper.Map<Bid>(bidDTO);
            await _bidService.CreateABidAsync(bid);
            return Created();
        }

        // PUT api/<BidController>/5
        [HttpPut]
        [Route("UpdateBid")]
        public async Task<ActionResult> UpdateBid(UpdateBidDTO updateBidDTO)
        {
            if (ModelState.IsValid)
            {
                Bid bid = _mapper.Map<Bid>(updateBidDTO);
                await _bidService.UpdateBidAsync(bid);
                return Created();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<BidController>/5
        [HttpDelete]
        [Route("DeleteBidById/{id:int}")]
        public async Task<ActionResult> DeleteBidById(int id)
        {
            await _bidService.DeleteBidByIDAsync(id);
            return Ok();
        }
    }
}
