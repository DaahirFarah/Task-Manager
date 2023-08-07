using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TaskM.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=TsData")
        {
            
        }

        public DbSet<Task> Tasks { get; set; }
    }
}