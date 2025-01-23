using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Data;

public class AppDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<ComputerEntity> Computers { get; set; }
    public DbSet<OrganizationEntity> Organizations { get; set; }
    private string DbPath { get; set; }
    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "computers.db");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={DbPath}")
            .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        string ADMIN_ID = Guid.NewGuid().ToString();
        string ROLE_ID = Guid.NewGuid().ToString();

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Name = "admin",
            NormalizedName = "ADMIN",
            Id = ROLE_ID,
            ConcurrencyStamp = ROLE_ID
        });
        
        var admin = new IdentityUser
        {
            Id = ADMIN_ID,
            Email = "adam@wsei.edu.pl",
            EmailConfirmed = true,
            UserName = "adam@wsei.edu.pl", // użyj pełnego emaila
            NormalizedUserName = "ADAM@WSEI.EDU.PL", // zgodnie z username
            NormalizedEmail = "ADAM@WSEI.EDU.PL"
        };
        
        PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
        admin.PasswordHash = ph.HashPassword(admin, "1234abcd!@#$ABCD");
        
        modelBuilder.Entity<IdentityUser>().HasData(admin);

        modelBuilder.Entity<IdentityUserRole<string>>()
            .HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
        
        modelBuilder.Entity<OrganizationEntity>().OwnsOne(e => e.Address);

        modelBuilder.Entity<ComputerEntity>().HasOne(e => e.Organization).WithMany(o => o.Computers)
            .HasForeignKey(e => e.OrganizationId);
        
        modelBuilder.Entity<ComputerEntity>()
            .Property(e => e.OrganizationId)
            .HasDefaultValue(101);

        modelBuilder.Entity<ComputerEntity>().Property(e => e.ProductionDate).HasDefaultValue(DateTime.Now);
        
        modelBuilder.Entity<OrganizationEntity>()
            .ToTable("organizations")
            .HasData(
                new OrganizationEntity()
                {
                    Id = 101,
                    Title = "WSEI",
                    Nip = "83492384",
                    Regon = "13424234",
                },
                new OrganizationEntity()
                {
                    Id = 102,
                    Title = "Firma",
                    Nip = "2498534",
                    Regon = "0873439249",
                }
            );

        modelBuilder.Entity<ComputerEntity>().HasData(
            new ComputerEntity()
            {
                Id = 1,
                Name = "Kompuer1",
                Processor = "Intel",
                GraphicsCard = "Nvidia",
                Manufacturer = "Dell",
                Memory = "8GB",
                ProductionDate = new DateTime(2020, 1, 1),
                OrganizationId = 101
            },
            new ComputerEntity()
            {
                Id = 2,
                Name = "Kompuer2",
                Processor = "AMD",
                GraphicsCard = "AMD Radeon",
                Manufacturer = "HP",
                Memory = "16GB",
                ProductionDate = new DateTime(2021, 1, 1),
                OrganizationId = 102
            }
        );

        modelBuilder.Entity<OrganizationEntity>().OwnsOne(e => e.Address).HasData(
            new { OrganizationEntityId = 101, City = "Kraków", Street = "Św. Filipa 17", PostalCode = "31-150", Region = "małopolskie" },
            new { OrganizationEntityId = 102, City = "Kraków", Street = "Krowoderska 45/6", PostalCode = "31-150", Region = "małopolskie" });
    }
}