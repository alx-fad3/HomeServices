using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HomeServices.Models
{
    public class HomeDbContext : DbContext
    {
        public HomeDbContext(DbContextOptions options) : base(options) { }

        public DbSet<FileModel> FileModels { get; set; }
        public DbSet<DirectoryModel> DirectoryModels { get; set; }

    }
}
