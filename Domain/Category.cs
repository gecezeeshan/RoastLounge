using System;
namespace Domain.Entities.Common
{
  public  class Category : AuditableEntity{
    
    
    public string? CategoryName {get; set;}
    public string? CategoryDescription {get; set;}

    public string? CategoryImage {get; set;}

    public ICollection<Cuisine>? Cuisines {get; set;}
    

  }

}
