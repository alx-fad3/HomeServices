using System.Collections.Generic;
using HomeServices.Models;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HomeServices.Services
{
    public class DbFiller
    {
        private readonly IFileManager _fileManager;
        private readonly DataManager _dataManager;
        private readonly HomeDbContext _db;

        public DbFiller(IFileManager fm, DataManager dm, HomeDbContext db)
        {
            _fileManager = fm;
            _dataManager = dm;
            _db = db;
        }

        public void FillDatabase(string path)
        {
            var directories = _fileManager.GetDirectoriesList(path);
            var dl = new List<DirectoryModel>();
            foreach (var d in directories)
            {
                dl.Add(new DirectoryModel
                {
                    Name = d.Split('\\').Last(),
                    Path = d
                });
            }
            _dataManager.Directories.AddDirectories(dl);

            FillFiles(path);
        }

        private void FillFiles(string path)
        {
            var files = _fileManager.GetFilesList(path);
            var fileInfos = new List<FileInfo>();
            foreach (var f in files)
            {
                fileInfos.Add(new FileInfo(f));
            }

            var dirs = _dataManager.Directories.GetAll();

            var fl = new List<FileModel>();
            foreach (var f in fileInfos)
            {
                fl.Add(new FileModel
                {
                    Name = f.Name,
                    Extension = f.Extension,
                    Size = (f.Length / 1024) / 1024,
                    Exists = f.Exists,
                    DirectoryId = dirs.FirstOrDefault(d => d.Path == f.DirectoryName).Id
                });
            }
            _dataManager.Files.AddFiles(fl);

            RemoveEmptyDirectories();
        }

        private void RemoveEmptyDirectories()
        {
            int z = _db.Database.ExecuteSqlRaw("exec sp_RemoveEmptyDirectories");
        }
    }
}