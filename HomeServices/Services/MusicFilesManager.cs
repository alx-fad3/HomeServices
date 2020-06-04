using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace HomeServices.Services
{
    public class MusicFilesManager : IFileManager
    {
        public IEnumerable<string> GetFilesList(string path)
        {
            if(!Directory.Exists(path)) throw new DirectoryNotFoundException();

            return Directory.GetFiles(path, "*.mp3", SearchOption.AllDirectories);
        }

        public IEnumerable<string> GetFilesList(char drive)
        {
            var drives = DriveInfo.GetDrives();

            var files = GetFilesList(
                drives.FirstOrDefault(d => d.Name.Contains(drive))?.Name);

            return files ?? throw new DriveNotFoundException();
        }

        public IEnumerable<string> GetDirectoriesList(string path)
        {
            if (!Directory.Exists(path)) throw new DirectoryNotFoundException();

            var directories = Directory.GetDirectories(path, "", SearchOption.AllDirectories).ToList();

            if(directories.Count == 0) directories.Add(path);

            return directories;
        }

        public byte[] GetFile(string path)
        {
            if (!File.Exists(path)) throw new FileNotFoundException();

            return File.ReadAllBytes(path);
        }

        public byte[] GetFiles(string path)
        {
            if (!Directory.Exists(path)) throw new DirectoryNotFoundException();

            ZipFile.CreateFromDirectory(path, $"{path}.zip");

            return File.ReadAllBytes($"{path}.zip");
        }

        public async Task<byte[]> GetFilesAsync(string path)
        {
            return await Task.Run(() => GetFiles(path));
        }

        public async Task<byte[]> GetFileAsync(string path)
        {
            return await Task.Run(() => GetFile(path));
        }
    }
}
