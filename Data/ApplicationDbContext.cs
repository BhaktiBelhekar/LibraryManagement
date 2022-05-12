using LibraryManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<AddBooks> AddBook { get; set; }
        public DbSet<StudentDetails> StudentDetail { get; set; }
        public DbSet<Issue_Books> IssueBook { get; set; }
        public DbSet<Return_Books> ReturnBook { get; set; }

    }
}

