using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploadAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            
            FileUploader uploader = new FileUploader();
            await uploader.WriteFile(file);
            return Ok();


        }


        [HttpPost("Multiple", Name = "Multiple")]
        [RequestFormLimits(MultipartBodyLengthLimit = 100000, ValueCountLimit = 2)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadFile(IFormFileCollection fileCollection)
        {
            FileUploader uploader = new FileUploader();
          
            foreach (var file in fileCollection)
            {
                await uploader.WriteFile(file);
            }
            return Ok();


        }
    }
}
