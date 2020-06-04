using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeServices.Models;

namespace HomeServices.Models.Repositories.Abstract
{
    public interface IDirectoryModelRepository
    {
        IQueryable<DirectoryModel> GetAll();
        DirectoryModel GetById(int id);
        DirectoryModel GetByPath(string path);
        void AddDirectory(DirectoryModel directory);
        void AddDirectories(IEnumerable<DirectoryModel> directories);
        void DeleteDirectory(int id);
    }
}
