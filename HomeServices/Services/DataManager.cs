using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeServices.Models.Repositories.Abstract;

namespace HomeServices.Services
{
    public class DataManager
    {
        public IDirectoryModelRepository Directories { get; set; }
        public IFileModelRepository Files { get; set; }

        public DataManager(IDirectoryModelRepository directoriesRepo, IFileModelRepository filesRepo)
        {
            Directories = directoriesRepo;
            Files = filesRepo;
        }
    }
}
