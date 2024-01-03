using Application.ResturantModule.Categories.CreateCategory;
using Application.ResturantModule.Categories.GetCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    
    public  class CategoryController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IList<CategoryViewModel>> Get(){
            
            return await Mediator.Send(new GetCategoryCommand() );
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCategoryCommand command){
            
            return await Mediator.Send(command);
        }

        [HttpGet("test")]
        public async Task<int> Test(){
            await Task.Delay(1000);
            return 1;
        }

    }

}