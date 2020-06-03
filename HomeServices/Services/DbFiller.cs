using System.Collections.Generic;
using HomeServices.Models;
using System.IO;
using System.Linq;

namespace HomeServices.Services
{
    public class DbFiller
    {
        private readonly MusicFilesManager _fileManager;
        private readonly DataManager _dataManager;

        public bool FillDatabase()
        {
            var directories = _fileManager.GetDirectoriesList("D:\\Music");
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
           
            return true;
        }

        public bool FillFiles()
        {
            var files = _fileManager.GetFilesList("D:\\Music");
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
                    Size = f.Length,
                    Exists = f.Exists,
                    DirectoryId = dirs.FirstOrDefault(d => d.Path == f.DirectoryName).Id
                });
            }
            _dataManager.Files.AddFiles(fl);
            return true;
        }
    }
}