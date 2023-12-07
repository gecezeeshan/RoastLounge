using System.ComponentModel.DataAnnotations;
using Application.Common.Interfaces;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly IDateTime? _dateTime;
        public ApplicationDbContext(DbContextOptions options, IDateTime? dateTime) : base(options)
        {
            _dateTime = dateTime;
        }
        public readonly IDateTime dateTime;
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cuisine> Cuisines { get; set; }

        public bool HasUnsavedChanges()
        {
            return this.ChangeTracker.HasChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                }
            }
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.LogTo(Console.WriteLine);
        }


    }

}