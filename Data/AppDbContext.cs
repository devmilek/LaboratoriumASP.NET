using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class AppDbContext : DbContext
{
    public DbSet<ComputerEntity> Computers { get; set; }
    private string DbPath { get; set; }
    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "computers.db");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ComputerEntity>().HasData(
            new ComputerEntity()
            {
                Id = 1,
                Name = "Adam",
                Processor = "Intel i7",
                Memory = "16GB",
                GraphicsCard = "NVIDIA GTX 1080",
                Manufacturer = "Dell",
                ProductionDate = new DateTime(2020, 1, 1)
            },
            new ComputerEntity()
            {
                Id = 2,
                Name = "Ewa",
                Processor = "AMD Ryzen 5",
                Memory = "8GB",
                GraphicsCard = "AMD Radeon RX 580",
                Manufacturer = "HP",
                ProductionDate = new DateTime(2019, 5, 15)
            }
        );
    }
}