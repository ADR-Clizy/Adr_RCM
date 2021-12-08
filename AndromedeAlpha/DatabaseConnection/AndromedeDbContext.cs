/*
*
* (c) 2021 Copyright Andromede
* Unauthorized use and disclosure strictly forbidden
*
*/

using Microsoft.EntityFrameworkCore;

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
