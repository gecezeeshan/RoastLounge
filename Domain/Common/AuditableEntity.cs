using System;
namespace Domain.Entities.Common
{
  public abstract class AuditableEntity{
    public int Id {get; set;}
    public DateTime Created {get; set;} = DateTime.Now;
    public string? CreatedBy {get; set;}
    public DateTime? LastModified {get; set;}
    public string? LastModifiedBy {get; set;}

  }

}
