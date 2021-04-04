using System;

using Microsoft.EntityFrameworkCore;

using SimpleAccountBook.Entities;

namespace SimpleAccountBook.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<GeneralCode> Codes { get; set; }

        public DbSet<Business> Businesses { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Stock> Stocks { get; set; }
    }
}
