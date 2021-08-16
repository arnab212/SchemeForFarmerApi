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
    public class SoldDetailsController : ControllerBase
    {
        private readonly SchemeForFarmerContext _context;

        public SoldDetailsController(SchemeForFarmerContext context)
        {
            _context = context;
        }

        // GET: api/SoldDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SoldDetail>>> GetSoldDetails()
        {
            return await _context.SoldDetails.ToListAsync();
        }

        // GET: api/SoldDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SoldDetail>> GetSoldDetail(int id)
        {
            var soldDetail = await _context.SoldDetails.FindAsync(id);

            if (soldDetail == null)
            {
                return NotFound();
            }

            return soldDetail;
        }

        [HttpGet("GetByAadhar/{id}")]
        public async Task<ActionResult<IEnumerable<SoldDetail>>> GetSoldByAadhar(string id)
        {
            var soldDetail = await _context.SoldDetails.ToListAsync();
            List<SoldDetail> valid = new List<SoldDetail>();
            foreach (SoldDetail req in soldDetail)
            {
                if (req.AadharCardNumber == id)
                {
                    valid.Add(req);
                }
            }
            if (valid == null)

            {
                return NotFound();
            }
            else
            {

                return valid;
            }

        }

        // PUT: api/SoldDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoldDetail(int id, SoldDetail soldDetail)
        {
            if (id != soldDetail.RequestId)
            {
                return BadRequest();
            }

            _context.Entry(soldDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoldDetailExists(id))
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

        // POST: api/SoldDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SoldDetail>> PostSoldDetail(SoldDetail soldDetail)
        {
            _context.SoldDetails.Add(soldDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSoldDetail", new { id = soldDetail.RequestId }, soldDetail);
        }

        // DELETE: api/SoldDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSoldDetail(int id)
        {
            var soldDetail = await _context.SoldDetails.FindAsync(id);
            if (soldDetail == null)
            {
                return NotFound();
            }

            _context.SoldDetails.Remove(soldDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SoldDetailExists(int id)
        {
            return _context.SoldDetails.Any(e => e.RequestId == id);
        }
    }
}
