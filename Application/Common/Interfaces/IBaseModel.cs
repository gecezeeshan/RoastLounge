using Application.ResturantModule.LoggedInUser;

namespace Application.Common.Interfaces 
{

 public interface IBaseModel{
    public LoggedInUserViewModel userViewModel {get; set; }
    
 }

}