using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeServices.Models
{
    public class DirectoryModel
    {
        public int Id { get; set; }

        [Display(Name = "Directory name")]
        public string Name { get; set; }

        [Display(Name = "Directory path")]
        public string Path { get; set; }
        public virtual ICollection<FileModel> Files { get; set; }
    }
}
