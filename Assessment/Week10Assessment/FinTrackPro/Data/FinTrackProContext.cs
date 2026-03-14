using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinTrackPro.Models;

public class FinTrackProContext : DbContext
{
    public FinTrackProContext(DbContextOptions<FinTrackProContext> options)
        : base(options)
    {
    }

    public DbSet<FinTrackPro.Models.Transaction> Transaction { get; set; } = default!;
    public DbSet<Account> Account { get; set; }


    public DbSet<FinTrackPro.Models.Assets> Assets { get; set; } = default!;
}
