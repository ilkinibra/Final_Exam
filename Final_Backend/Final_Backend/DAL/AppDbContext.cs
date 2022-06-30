using Final_Backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Backend.DAL
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }
        public DbSet<PageIntro> pageIntros { get; set; }
        public DbSet<What> Whats { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Web> webs { get; set; }
    }
}
