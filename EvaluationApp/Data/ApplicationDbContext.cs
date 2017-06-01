using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EvaluationApp.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EvaluationApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);


        }

        public DbSet<Students> Students { get; set; }
        public DbSet<Lecturers> Lecturers { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Lectures> Lectures { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<DataOfUnderstanding> DataOfUnderstanding { get; set; }
    }

    //public class TemporaryDbContextFactory : IDbContextFactory<ApplicationDbContext>
    //{
    //    public ApplicationDbContext Create()
    //    {
    //        var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
    //        builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=pinchdb;Trusted_Connection=True;MultipleActiveResultSets=true");
    //        return new ApplicationDbContext(builder.Options);
    //    }
    //}


}
