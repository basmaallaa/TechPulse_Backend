using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace TechPulse.BL.Helper
{
    public class FileHelper
    {
        public static async Task<string> UploadFileAsync(IFormFile file)
        {
            try
            {
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/uploads");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(folderPath, fileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(stream);
                return $"uploads/{fileName}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
