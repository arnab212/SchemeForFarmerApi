using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchemeForFarmerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        
        private readonly IWebHostEnvironment _env;
        public UploadController( IWebHostEnvironment env)
        {
            _env = env;
            
        }

        [HttpGet("{uid}")]
        public FileResult Upload(string uid)
        {
            
            var fs = System.IO.File.OpenRead(_env.WebRootPath + "\\uploads\\" + uid);

            // FETCH filename FROM DATABASE ENTRY BY uid
            Response.Headers.Add("Content-Disposition", "inline");
            return File(fs, "application/pdf", "PUT_YOUR_FILE_NAME_HERE_FROM_DATABASE.pdf");
        }

        [HttpPost]
        public async Task<ActionResult> Upload()
        {
            Dictionary<string, string> keys = new();
            foreach (IFormFile source in Request.Form.Files)
            {
                string filename = source.FileName;

                string uid = Guid.NewGuid().ToString("N");
                using var output = System.IO.File.Create(_env.WebRootPath + "\\uploads\\" + uid);
                keys.Add(source.Name, uid);

                // STORE (uid, filename) IN DATABASE

                await source.CopyToAsync(output);
            }
            return new JsonResult(keys);
        }
    }
}
