using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchemeForFarmerApi.SchemeForFarmerModel;

namespace SchemeForFarmerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmerDetailsController : ControllerBase
    {
        private readonly SchemeForFarmerContext _context;
       
        public FarmerDetailsController(SchemeForFarmerContext context)
        {
           
            _context = context;
        }

        

        // GET: api/FarmerDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FarmerDetail>>> GetFarmerDetails()
        {
            return await _context.FarmerDetails.ToListAsync();
        }

        // GET: api/FarmerDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FarmerDetail>> GetFarmerDetail(string id)
        {
            var farmerDetail = await _context.FarmerDetails.FindAsync(id);

            if (farmerDetail == null)
            {
                return NotFound();
            }

            return farmerDetail;
        }

        // PUT: api/FarmerDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFarmerDetail(string id, FarmerDetail farmerDetail)
        {
            if (id != farmerDetail.AadharCardNumber)
            {
                return BadRequest();
            }

            _context.Entry(farmerDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FarmerDetailExists(id))
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

        // POST: api/FarmerDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FarmerDetail>> PostFarmerDetail(FarmerDetail farmerDetail)
        {
            _context.FarmerDetails.Add(farmerDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FarmerDetailExists(farmerDetail.AadharCardNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFarmerDetail", new { id = farmerDetail.AadharCardNumber }, farmerDetail);
        }

        // DELETE: api/FarmerDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFarmerDetail(string id)
        {
            var farmerDetail = await _context.FarmerDetails.FindAsync(id);
            if (farmerDetail == null)
            {
                return NotFound();
            }

            _context.FarmerDetails.Remove(farmerDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FarmerDetailExists(string id)
        {
            return _context.FarmerDetails.Any(e => e.AadharCardNumber == id);
        }
    }
}
