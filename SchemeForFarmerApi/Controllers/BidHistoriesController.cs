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
    public class BidHistoriesController : ControllerBase
    {
        private readonly SchemeForFarmerContext _context;

        public BidHistoriesController(SchemeForFarmerContext context)
        {
            _context = context;
        }

        // GET: api/BidHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BidHistory>>> GetBidHistories()
        {
            return await _context.BidHistories.ToListAsync();
        }

        // GET: api/BidHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BidHistory>> GetBidHistory(int id)
        {
            var bidHistory = await _context.BidHistories.FindAsync(id);

            if (bidHistory == null)
            {
                return NotFound();
            }

            return bidHistory;
        }

        [HttpGet("PreviousBids/{id}")]
        public async Task<ActionResult<IEnumerable<BidHistory>>> GetLatestBidHistory(int id)
        {
            var bidHistory = await _context.BidHistories.ToListAsync();
            List<BidHistory> PreviousBid = new List<BidHistory>();
            foreach( BidHistory b in bidHistory)
            {
                if(b.RequestId==id)
                {
                    PreviousBid.Add(b);
                }
                
            }
            if (PreviousBid == null)
            {
                return NotFound();
            }

            return PreviousBid;
        }
        [HttpGet("LatestBid/{id}")]
        public async Task<ActionResult<BidHistory>> GetPreviousBidHistory(int id)
        {
            var bidHistory = await _context.BidHistories.ToListAsync();
            BidHistory latestbid = null;
            foreach (BidHistory b in bidHistory)
            {
                if (b.RequestId == id)
                {
                    latestbid = b;
                }
            }
            if (latestbid == null)
            {
                return NotFound();
            }

            return latestbid;
        }

        // PUT: api/BidHistories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBidHistory(int id, BidHistory bidHistory)
        {
            if (id != bidHistory.BidId)
            {
                return BadRequest();
            }

            _context.Entry(bidHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BidHistoryExists(id))
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

        // POST: api/BidHistories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BidHistory>> PostBidHistory(BidHistory bidHistory)
        {
            _context.BidHistories.Add(bidHistory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BidHistoryExists(bidHistory.BidId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBidHistory", new { id = bidHistory.BidId }, bidHistory);
        }

        // DELETE: api/BidHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBidHistory(int id)
        {
            var bidHistory = await _context.BidHistories.FindAsync(id);
            if (bidHistory == null)
            {
                return NotFound();
            }

            _context.BidHistories.Remove(bidHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BidHistoryExists(int id)
        {
            return _context.BidHistories.Any(e => e.BidId == id);
        }
    }
}
