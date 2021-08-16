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
    public class CityStatesController : ControllerBase
    {
        private readonly SchemeForFarmerContext _context;

        public CityStatesController(SchemeForFarmerContext context)
        {
            _context = context;
        }

        // GET: api/CityStates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityState>>> GetCityStates()
        {
            return await _context.CityStates.ToListAsync();
        }

        // GET: api/CityStates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CityState>> GetCityState(string id)
        {
            var cityState = await _context.CityStates.FindAsync(id);

            if (cityState == null)
            {
                return NotFound();
            }

            return cityState;
        }

        // PUT: api/CityStates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCityState(string id, CityState cityState)
        {
            if (id != cityState.City)
            {
                return BadRequest();
            }

            _context.Entry(cityState).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityStateExists(id))
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

        // POST: api/CityStates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CityState>> PostCityState(CityState cityState)
        {
            _context.CityStates.Add(cityState);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CityStateExists(cityState.City))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCityState", new { id = cityState.City }, cityState);
        }

        // DELETE: api/CityStates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCityState(string id)
        {
            var cityState = await _context.CityStates.FindAsync(id);
            if (cityState == null)
            {
                return NotFound();
            }

            _context.CityStates.Remove(cityState);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CityStateExists(string id)
        {
            return _context.CityStates.Any(e => e.City == id);
        }
    }
}
