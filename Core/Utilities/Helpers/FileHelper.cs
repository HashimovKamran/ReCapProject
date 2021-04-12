using Core.Result;
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
            var result = newPath(file);
            try
            {
                var sourcePath = Path.GetTempFileName();
                if (file.Length > 0)
                {
                    using (var stream = new FileStream(sourcePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                File.Move(sourcePath, result);
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
            return result;
        }

        public static string Update(string oldPath, IFormFile file)
        {
            var result = newPath(file);
            try
            {
                if (oldPath.Length > 0)
                {
                    using (var stream = new FileStream(result, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                File.Delete(oldPath);
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
            return result;
        }

        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }
            return new SuccessResult();
        }

        private static string newPath(IFormFile file)
        {
            FileInfo fileName = new FileInfo(file.FileName);
            string fileExtension = fileName.Extension;

            string path = Environment.CurrentDirectory + @"\wwwroot\Images";
            var newPath = Guid.NewGuid().ToString() + fileExtension;

            string result = $@"{path}\{newPath}";
            return result;
        }
    }
}