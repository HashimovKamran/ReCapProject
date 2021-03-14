using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var sourcePath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var uploading = new FileStream(sourcePath, FileMode.Create))
                {
                    file.CopyTo(uploading);
                }
            }
            var result = newPath(file);
            File.Move(sourcePath, result);
            return result;
        }

        private static string newPath(IFormFile file)
        {
            FileInfo fileName = new FileInfo(file.FileName);
            string fileExtension = fileName.Extension;

            string path = Environment.CurrentDirectory + @"\Images";
            var newPath = Guid.NewGuid().ToString() + fileExtension;

            string result = $@"{path}\{newPath}";
            return result;
        }
    }
}