using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskM.Models
{
    public class Task
    {
        [Key, Required, Display(Name = "Id")]
        public int TaskId { get; set; }

        [Required, Display(Name = "Name")]
        public string TaskName { get; set; }

        [Required, Display(Name = "Description")]
        public string TaskDesc { get; set; }

        [Required, Display(Name = "Priority")]
        public string TaskPri { get; set;}
    }
}