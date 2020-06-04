using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HomeServices.Models;
using HomeServices.Services;
using System.Net;
using System.Net.Sockets;

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
            ViewBag.localIp = GetLocalIPAddress();
            return View();
        }

        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
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