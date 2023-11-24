using System;
namespace Domain.Entities.Common
{
  public  class Cuisine : AuditableEntity{
    public string? CuisineName {get; set;}
    public string? CuisineDescription {get; set;}

    public string? CuisineImage {get; set;}
  }

}
