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
        [RequestFormLimits(MultipartBodyLengthLimit = 10000000, ValueCountLimit = 10)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadFile(IFormFileCollection files)
        {
            if (files == null)
            {

                throw new ArgumentException("please upload the file using files key");

            }

            FileUploader uploader = new FileUploader();
          
            foreach (var file in files)
            {
                await uploader.WriteFile(file);
            }
            return Ok();


        }
    }
}
