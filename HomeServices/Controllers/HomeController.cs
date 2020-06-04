using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HomeServices.Models;
using HomeServices.Services;

namespace HomeServices.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFileManager _fileManager;
        private readonly DataManager _dataManager;
        private readonly DbFiller _dbFiller;

        public HomeController(IFileManager fm, DataManager dm, DbFiller df)
        {
            _fileManager = fm;
            _dataManager = dm;
            _dbFiller = df;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MusicList()
        {
            var directories =_dataManager.Directories
                .GetAll().OrderBy(d => d.Name);
            return View(directories);
        }

        public IActionResult FilesInDirectory(int id)
        {
            var files = _dataManager.Files
                .GetByDirectoryId(id)
                .OrderBy(f => f.Name).ToList();

            ViewBag.directoryName = _dataManager.Directories.GetAll()
                .FirstOrDefault(d => d.Id == id).Path;

            ViewBag.directoryId = id;

            return View(files);
        }
    }
}