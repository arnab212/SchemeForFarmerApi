using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchemeForFarmerApi.SchemeForFarmerModel;

namespace SchemeForFarmerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidderDetailsController : ControllerBase
    {
        private readonly SchemeForFarmerContext _context;

        public BidderDetailsController(SchemeForFarmerContext context)
        {
            _context = context;
        }

        // GET: api/BidderDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BidderDetail>>> GetBidderDetails()
        {
            return await _context.BidderDetails.ToListAsync();
        }

        // GET: api/BidderDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BidderDetail>> GetBidderDetail(string id)
        {
            var bidderDetail = await _context.BidderDetails.FindAsync(id);

            if (bidderDetail == null)
            {
                return NotFound();
            }

            return bidderDetail;
        }

        // PUT: api/BidderDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBidderDetail(string id, BidderDetail bidderDetail)
        {
            if (id != bidderDetail.AadharCardNumber)
            {
                return BadRequest();
            }

            _context.Entry(bidderDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BidderDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BidderDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BidderDetail>> PostBidderDetail(BidderDetail bidderDetail)
        {
            _context.BidderDetails.Add(bidderDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BidderDetailExists(bidderDetail.AadharCardNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBidderDetail", new { id = bidderDetail.AadharCardNumber }, bidderDetail);
        }

        // DELETE: api/BidderDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBidderDetail(string id)
        {
            var bidderDetail = await _context.BidderDetails.FindAsync(id);
            if (bidderDetail == null)
            {
                return NotFound();
            }

            _context.BidderDetails.Remove(bidderDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BidderDetailExists(string id)
        {
            return _context.BidderDetails.Any(e => e.AadharCardNumber == id);
        }
    }
}
