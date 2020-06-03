using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeServices.Models;

namespace HomeServices.Models.Repositories.Abstract
{
    public interface IFileModelRepository
    {
        IQueryable<FileModel> GetAll();
        IQueryable<FileModel> GetByDirectoryId(int id);
        FileModel GetById(int id);
        FileModel GetByExtension(string ext);
        void AddFile(FileModel file);
        void AddFiles(IEnumerable<FileModel> files);
    }
}
