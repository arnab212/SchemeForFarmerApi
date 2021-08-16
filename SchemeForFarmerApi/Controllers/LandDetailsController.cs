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
    public class LandDetailsController : ControllerBase
    {
        private readonly SchemeForFarmerContext _context;

        public LandDetailsController(SchemeForFarmerContext context)
        {
            _context = context;
        }

        // GET: api/LandDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LandDetail>>> GetLandDetails()
        {
            return await _context.LandDetails.ToListAsync();
        }

        // GET: api/LandDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LandDetail>> GetLandDetail(int id)
        {
            var landDetail = await _context.LandDetails.FindAsync(id);

            if (landDetail == null)
            {
                return NotFound();
            }

            return landDetail;
        }

        // PUT: api/LandDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLandDetail(int id, LandDetail landDetail)
        {
            if (id != landDetail.LandId)
            {
                return BadRequest();
            }

            _context.Entry(landDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LandDetailExists(id))
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

        // POST: api/LandDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LandDetail>> PostLandDetail(LandDetail landDetail)
        {
            _context.LandDetails.Add(landDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLandDetail", new { id = landDetail.LandId }, landDetail);
        }

        // DELETE: api/LandDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLandDetail(int id)
        {
            var landDetail = await _context.LandDetails.FindAsync(id);
            if (landDetail == null)
            {
                return NotFound();
            }

            _context.LandDetails.Remove(landDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LandDetailExists(int id)
        {
            return _context.LandDetails.Any(e => e.LandId == id);
        }
    }
}
