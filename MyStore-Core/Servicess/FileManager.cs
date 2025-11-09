using Microsoft.AspNetCore.Http;
using MyStore_Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using Image = SixLabors.ImageSharp.Image;

namespace MyStore_Core.Servicess
{
    public class FileManager : IFileManager
    {

        public void DeleteFile(string fileName, string path)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), path, fileName);
            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        public string SaveFile(IFormFile File, string Savepath)
        {

            if (File == null) throw new ArgumentNullException("file is null");

            var Filename = $"{Guid.NewGuid()}{File.FileName}";
            var folderpath = Path.Combine(Directory.GetCurrentDirectory(), Savepath.Replace("/", "\\"));
            if (!Directory.Exists(folderpath))
            {
                Directory.CreateDirectory(folderpath);
            }
            var Fullpath = Path.Combine(folderpath, Filename);
            using (Image image = Image.Load(File.OpenReadStream()))
            {
                image.Mutate(x => x.Resize(1920, 600));

                image.Save(Fullpath);

                return Filename;
            }
        }

    }
}
