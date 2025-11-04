using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore_Core.Interfaces
{
    public interface IFileManager
    {

        string SaveFile(IFormFile file, string Savepath);
    }
}
