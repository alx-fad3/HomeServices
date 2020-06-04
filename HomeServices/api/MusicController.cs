using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HomeServices.Services;
using System;
using System.Threading.Tasks;

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

        [HttpGet("test")]
        public string Test()
        
        {
            FillDatabase("D:\\Music");
            return "ololo";
        }

        [HttpGet("getzip")]
        public async Task<IActionResult> GetDirectoryZip(int id)
        {
            var dirs = _dataManager.Directories.GetAll();
            var dir = dirs.FirstOrDefault(d => d.Id == id);
            var zipFileName = dir.Path.Split('\\').Last() + ".zip";
            return File(await _fileManager.GetFilesAsync(dir.Path), "application/zip", zipFileName);
        }

        [HttpGet("filldb")]
        public string FillDatabase(string path)
        {
            _dbFiller.FillDatabase(path);
            _dbFiller.FillFiles(path);

            return $"Added: {path}";
        }

        [HttpGet("getfile")]
        public async Task<IActionResult> GetFile(int id)
        {
            var file = _dataManager.Files.GetById(id);
            var directory = _dataManager.Directories.GetById((int)file.DirectoryId);
            return File(await _fileManager.GetFileAsync($"{directory.Path}\\{file.Name}"), "audio/mpeg", file.Name);
        }

        [HttpDelete("{id}")]
        public async Task DeleteFile(int id)
        {
            await Task.Run(() => _dataManager.Files.DeleteFile(id));
        }

        [HttpDelete("deletedir/{id}")]
        public async Task DeleteDirectory(int id)
        {
            await Task.Run(() => _dataManager.Directories.DeleteDirectory(id));
        }
    }
}
