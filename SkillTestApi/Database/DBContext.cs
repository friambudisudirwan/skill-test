using System;
using Microsoft.EntityFrameworkCore;
using SkillTestApi.Models;

namespace SkillTestApi.Database;

public class DBContext : DbContext
{
    public DbSet<Transaksi> Transaksi { get; set; }
    public DBContext(DbContextOptions<DBContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaksi>().HasKey(x => x.TransaksiID);
    }
}
