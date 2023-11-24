using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces 
{

 public interface IApplicationDbContext{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Cuisine> Cuisines { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    public bool HasUnsavedChanges();
    
 }

}