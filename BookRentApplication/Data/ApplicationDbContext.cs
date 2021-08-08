using System;
using System.Collections.Generic;
using System.Text;
using BookRentApplication.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookRentApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "Admin" });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "User", NormalizedName = "User" });
           
            modelBuilder.Entity<Book>()
             .HasOne<Author>(s => s.Author)
             .WithMany(g => g.Books)
             .HasForeignKey(s => s.AuthorId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
