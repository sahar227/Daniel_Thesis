using DBModel.Trail;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel
{
    public class SampleDBContext : DbContext
    {
        private const string DatabaseDir = @"C:\ThesisUtils";
        private const string DatabaseFileName = "Thesis.db";
        public SampleDBContext()
        {
            SQLitePCL.Batteries.Init();
            if (!File.Exists(Path.Combine(DatabaseDir,DatabaseFileName)))
            {
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            string directory = @"C:\ThesisUtils";
            Directory.CreateDirectory(directory);
            string connection = "Data Source=";
            connection += Path.Combine(DatabaseDir, DatabaseFileName);
            optionbuilder.UseSqlite(connection);
        }

        public DbSet<TrailOne> TrailOnes { get; set; }
        public DbSet<TrailTwo> TrailTwos { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
