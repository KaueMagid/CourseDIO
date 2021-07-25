using Course.api.Business.Entities;
using Course.api.Infraestruture.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.api.Infraestruture.Data
{
    public class CourseDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        //public DbSet<Courses> Courses;

        public CourseDbContext(DbContextOptions<CourseDbContext> options):base(options)
        {
           
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            base.OnModelCreating(modelBuilder);
        }

    }
}
