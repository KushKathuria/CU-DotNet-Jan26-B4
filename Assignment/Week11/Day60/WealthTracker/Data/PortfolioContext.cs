using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WealthTracker.Models;

    public class PortfolioContext : DbContext
    {
        public PortfolioContext (DbContextOptions<PortfolioContext> options)
            : base(options)
        {
        }

        public DbSet<WealthTracker.Models.Investment> Investment { get; set; } = default!;
    }
