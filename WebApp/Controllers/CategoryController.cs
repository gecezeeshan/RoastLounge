using Application.ResturantModule.Categories.CreateCategory;
using Application.ResturantModule.Categories.GetCategory;
using Domain.Entities.Common;

namespace RoastLounge.WebAPI.Controllers
{
    public class CategoryController : ApiController
    {
        public async Task<List<Category>> Get(){
            return await Mediator.Send(new GetCategoryCommand() );
        }

        public async Task<int> Create(CreateCategoryCommand command){
            return await Mediator.Send(command);
        }
    }
    
}