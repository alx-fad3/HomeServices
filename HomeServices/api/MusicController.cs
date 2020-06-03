using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HomeServices.Services;
using System;

namespace HomeServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicController : ControllerBase
    {
        private readonly IFileManager _fileManager;
        private readonly DataManager _dataManager;
        private readonly DbFiller _dbFiller;

        public MusicController(IFileManager fm, DataManager dm, DbFiller df)
        {
            _fileManager = fm;
            _dataManager = dm;
            _dbFiller = df;
        }


        [HttpGet("getzip")]
        public IActionResult GetDirectoryZip(int id)
        {
            var dirs = _dataManager.Directories.GetAll();
            var dir = dirs.FirstOrDefault(d => d.Id == id);
            var zipFileName = dir.Path.Split('\\').Last() + ".zip";
            return File(_fileManager.GetFiles(dir.Path), "application/zip", zipFileName);
        }

        public string FillDatabase()
        {
            var dirsReady = _dbFiller.FillDatabase();
            var filesReady = _dbFiller.FillFiles();

            return "Ready";
        }

        [HttpGet("getfile")]
        public IActionResult GetFile(int id)
        {
            var file = _dataManager.Files.GetById(id);
            var directory = _dataManager.Directories.GetById(file.DirectoryId);
            return File(_fileManager.GetFile($"{directory.Path}\\{file.Name}"), "audio/mpeg", file.Name);
        }
    }
}
