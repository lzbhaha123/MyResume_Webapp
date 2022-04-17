#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyResume.Models;

namespace MyResume.Data
{
    public class MyResumeContext : DbContext
    {
        public MyResumeContext (DbContextOptions<MyResumeContext> options)
            : base(options)
        {
        }

        public DbSet<MyResume.Models.Experience> Experience { get; set; }

        public DbSet<MyResume.Models.Article> Article { get; set; }

        public DbSet<MyResume.Models.Portfolio> Portfolio { get; set; }

        public DbSet<MyResume.Models.Skill> Skill { get; set; }

        public DbSet<MyResume.Models.Message> Message { get; set; }

        public DbSet<MyResume.Models.Project> Project { get; set; }
    }
}
