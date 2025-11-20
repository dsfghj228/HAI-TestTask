using Back.Models;
using Microsoft.EntityFrameworkCore;

namespace Back.Data;

public class ApplicationDbContext  : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
    
    public DbSet<Disease> Diseases  { get; set; }
    public DbSet<Doctor>  Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>()
            .HasMany(d => d.Patients)
            .WithOne(p => p.Doctor)
            .HasForeignKey(d => d.DoctorId);

        modelBuilder.Entity<Patient>()
            .HasMany(p => p.Diseases)
            .WithMany(d => d.Patients);
    }
}