using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
       

        public string Name { get; set; }

        public DbSet<Smartphone> Smartphones { get; set; }

        public DbSet<Battery> Battery { get; set; }

        public DbSet<Body> Body { get; set; }

        public DbSet<Connect> Connect { get; set; }

        public DbSet<Display> Display { get; set; }

        public DbSet<Features> Features { get; set; }

        public DbSet<Date> Date { get; set; }

        public DbSet<MainCamera> MainCamera { get; set; }

        public DbSet<Memory> Memory { get; set; }

        public DbSet<View> View { get; set; }

        public DbSet<Network> Network { get; set; }

        public DbSet<Hardware> Hardware { get; set; }

        public DbSet<SelfieCamera> SelfieCamera { get; set; }

        public DbSet<Sound> Sound { get; set; }

        public DbSet<Image> Image { get; set; }

        public DbSet<RankingPremiumSmartphones> RankingPremiumSmartphones { get; set; }
    }

}
