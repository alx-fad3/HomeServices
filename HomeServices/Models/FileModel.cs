using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeServices.Models
{
    public class FileModel
    {
        public int Id { get; set; }
        [Display(Name = "File name")]
        public string Name { get; set; }
        [Display(Name = "Extension")]
        public string Extension { get; set; }
        [Display(Name = "Size")]
        public double Size { get; set; }
        public bool Exists { get; set; }
        public int? DirectoryId { get; set; }
        public virtual DirectoryModel DirectoryModel { get; set; }

    }
}
