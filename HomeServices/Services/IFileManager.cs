using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeServices.Services
{
    public interface IFileManager
    {
        IEnumerable<string> GetFilesList(string path);
        IEnumerable<string> GetFilesList(char drive);
        IEnumerable<string> GetDirectoriesList(string path);
        byte[] GetFile(string path);
        byte[] GetFiles(string path);
        
    }
}
