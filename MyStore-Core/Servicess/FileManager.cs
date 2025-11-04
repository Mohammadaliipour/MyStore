using Microsoft.AspNetCore.Http;
using MyStore_Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore_Core.Servicess
{
    public class FileManager : IFileManager
    {
       public string SaveFile(IFormFile File,string Savepath) 
        {
        
        if (File == null) throw new ArgumentNullException("file is null");

            var Filename = $"{Guid.NewGuid()}{File.FileName}";
            var folderpath=Path.Combine(Directory.GetCurrentDirectory(), Savepath.Replace("/","\\"));
            if (!Directory.Exists(folderpath)) 
            {
            Directory.CreateDirectory(folderpath);
            }
            var Fullpath=Path.Combine(folderpath,Filename);
            using var stream=new FileStream(Fullpath, FileMode.Create);
            File.CopyTo(stream);
            return Filename;
       
        }

    }
}
