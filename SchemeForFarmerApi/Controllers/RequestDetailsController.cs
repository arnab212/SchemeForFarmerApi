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
    public class RequestDetailsController : ControllerBase
    {
        private readonly SchemeForFarmerContext _context;

        public RequestDetailsController(SchemeForFarmerContext context)
        {
            _context = context;
        }

        // GET: api/RequestDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestDetail>>> GetRequestDetails()
        {
            return await _context.RequestDetails.ToListAsync();
        }

        // GET: api/RequestDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestDetail>> GetRequestDetail(int id)
        {
            var requestDetail = await _context.RequestDetails.FindAsync(id);

            if (requestDetail == null)
            {
                return NotFound();
            }

            return requestDetail;
        }

        [HttpGet("GetByAadharandStatus/{id}")]
        public async Task<ActionResult<IEnumerable<RequestDetail>>> GetRequestByAadharAndStatus(string id)
        {
            var requestDetail = await _context.RequestDetails.ToListAsync();
            List<RequestDetail> valid = new List<RequestDetail>();
            foreach (RequestDetail req in requestDetail)
            {
                if (req.AadharCardNumber == id && req.Status==false)
                {
                    valid.Add(req);
                }
            }
            if (valid==null)

            {
                return NotFound();
            }
            else
            {

                return valid;
            }

        }

        [HttpGet("GetByAadhar/{id}")]
        public async Task<ActionResult<IEnumerable<RequestDetail>>> GetRequestByAadhar(string id)
        {
            var requestDetail = await _context.RequestDetails.ToListAsync();
            List<RequestDetail> valid = new List<RequestDetail>();
            foreach (RequestDetail req in requestDetail)
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

        // PUT: api/RequestDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequestDetail(int id, RequestDetail requestDetail)
        {
            if (id != requestDetail.RequestId)
            {
                return BadRequest();
            }

            _context.Entry(requestDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestDetailExists(id))
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

        // POST: api/RequestDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RequestDetail>> PostRequestDetail(RequestDetail requestDetail)
        {
            _context.RequestDetails.Add(requestDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequestDetail", new { id = requestDetail.RequestId }, requestDetail);
        }

        // DELETE: api/RequestDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequestDetail(int id)
        {
            var requestDetail = await _context.RequestDetails.FindAsync(id);
            if (requestDetail == null)
            {
                return NotFound();
            }

            _context.RequestDetails.Remove(requestDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequestDetailExists(int id)
        {
            return _context.RequestDetails.Any(e => e.RequestId == id);
        }
    }
}
