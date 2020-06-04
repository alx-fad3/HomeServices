using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeServices.Models.Repositories.Abstract;
using HomeServices.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeServices.Models.Repositories.EntityFramework
{
    public class EFFileModelRepository : IFileModelRepository
    {
        private readonly HomeDbContext _db;

        public EFFileModelRepository(HomeDbContext db)
        {
            _db = db;
        }

        public IQueryable<FileModel> GetAll()
        {
            return _db.FileModels;
        }

        public IQueryable<FileModel> GetByDirectoryId(int id)
        {
            return _db.FileModels.Where(f => f.DirectoryId == id);
        }

        public FileModel GetById(int id)
        {
            return _db.FileModels.FirstOrDefault(f => f.Id == id);
        }

        public FileModel GetByExtension(string ext)
        {
            return _db.FileModels.FirstOrDefault(f => f.Extension == ext);
        }

        public void AddFile(FileModel file)
        {
            _db.FileModels.Add(file);
            _db.SaveChanges();
        }

        public void AddFiles(IEnumerable<FileModel> files)
        {
            if(files.ToList().Count > 15)
            {
                foreach(var f in files)
                {
                    AddFile(f);
                }
            }
            else
            {
                _db.AddRange(files);
                _db.SaveChanges();
            }
        }

        public void DeleteFile(int id)
        {
            var d = _db.FileModels.FirstOrDefault(f => f.Id == id);
            _db.FileModels.Remove(d);
            _db.SaveChanges();
        }
    }
}
