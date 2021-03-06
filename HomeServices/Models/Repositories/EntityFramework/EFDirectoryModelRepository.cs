﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeServices.Models.Repositories.Abstract;
using HomeServices.Models;

namespace HomeServices.Models.Repositories.EntityFramework
{
    public class EFDirectoryModelRepository : IDirectoryModelRepository
    {
        private readonly HomeDbContext _db;

        public EFDirectoryModelRepository(HomeDbContext db)
        {
            _db = db;
        }

        public IQueryable<DirectoryModel> GetAll()
        {
            return _db.DirectoryModels;
        }

        public DirectoryModel GetById(int id)
        {
            return _db.DirectoryModels.FirstOrDefault(d => d.Id == id);
        }

        public DirectoryModel GetByPath(string path)
        {
            return _db.DirectoryModels.FirstOrDefault(d => d.Path == path);
        }

        public void AddDirectory(DirectoryModel directory)
        {
            _db.DirectoryModels.Add(directory);
            _db.SaveChanges();
        }

        public void AddDirectories(IEnumerable<DirectoryModel> directories)
        {
            if(directories.ToList().Count > 15)
            {
                foreach(var d in directories)
                {
                    AddDirectory(d);
                }
            }
            else
            {
                _db.DirectoryModels.AddRange(directories);
                _db.SaveChanges();
            } 
        }

        public void DeleteDirectory(int id)
        {
            _db.DirectoryModels.Remove(
                _db.DirectoryModels.FirstOrDefault(d => d.Id == id));
            _db.SaveChanges();
        }
    }
}
