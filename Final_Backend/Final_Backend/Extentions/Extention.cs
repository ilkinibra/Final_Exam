using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Backend.Extentions
{
    public static class Extention
    {
            public static bool IsImage(this IFormFile file)
            {
                return file.ContentType.Contains("image");
            }
            public static bool ImageSize(this IFormFile file, int kb)
            {
                return file.Length / 1024 > kb;
            }
        
    }
}
