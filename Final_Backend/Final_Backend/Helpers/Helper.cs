using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Backend.Helpers
{
    public class Helper
    {
        private IWebHostEnvironment _env;
        public Helper(IWebHostEnvironment env)
        {
            _env = env;
        }

        public static void DeleteFile(IWebHostEnvironment env, string img, string image)
        {
            string path = env.WebRootPath;
            string resulPath = Path.Combine(path, image);

            if (System.IO.File.Exists(resulPath))
            {
                System.IO.File.Delete(resulPath);
            }
        }

    }
}
