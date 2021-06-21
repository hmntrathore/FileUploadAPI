using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploadAPI
{
    public class FileUploader
    {
        public async Task<bool> WriteFile(IFormFile file)
        {
            if (file == null)
            {
                throw new ArgumentException("please upload the file using file key");
            }

            string fileName = file.FileName;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Upload", fileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return true;
        }
           
        
    }
}
