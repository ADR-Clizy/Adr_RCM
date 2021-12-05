using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection
{
    public class AndromedeDbContext : DbContext
    {
        public DbSet<Restorer> Restorers { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<RestorerClaim> RestorerClaims { get; set; }

        public AndromedeDbContext(DbContextOptions<AndromedeDbContext> options) 
            : base(options)
        {

        }
    }
}
