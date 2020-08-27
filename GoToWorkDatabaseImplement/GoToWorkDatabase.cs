using System;
using System.Collections.Generic;
using System.Text;
using GoToWorkDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace GoToWorkDatabaseImplement
{
    class GoToWorkDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
<<<<<<< HEAD
                optionsBuilder.UseSqlServer(@"Data Source=juliazavr\SQLEXPRESS;Initial Catalog=GoToWorkDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
=======
                optionsBuilder.UseSqlServer(@"Data Source=NIA\SQLEXPRESS;Initial Catalog=GoToWorkDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
>>>>>>> c5de45aa0e96dc1a2a07dfc76df7593ac57c8152
            }
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Provider> Providers { set; get; }
        public DbSet<Part> Parts { set; get; }
        public DbSet<Toy> Toys { set; get; }
        public DbSet<ToyParts> ToyParts { set; get; }
        public DbSet<Request> Requests { set; get; }
    }
}