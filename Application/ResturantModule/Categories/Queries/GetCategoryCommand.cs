using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Application.Common.Interfaces;
using Domain.Entities.Common;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.ResturantModule.Categories.GetCategory
{


    public class GetCategoryCommand : IRequest<List<CategoryViewModel>>
    {

    }


    public class GetCategoryCommandHandler : IRequestHandler<GetCategoryCommand, List<CategoryViewModel>>
    {
        public readonly IApplicationDbContext _context;
        public GetCategoryCommandHandler(IApplicationDbContext context)
        {
            _context = context;            
        }

        public async Task<List<CategoryViewModel>> Handle(GetCategoryCommand request, CancellationToken cancellationToken)
        {

            var result = await _context.Categories.OrderBy(z => z.CategoryName).AsNoTracking().ToListAsync();
            var models = new List<CategoryViewModel>();

            foreach (var item in result)
            {
                var model = new CategoryViewModel()
                {
                    CategoryName = item.CategoryName,
                    CategoryDescription = item.CategoryDescription,
                    CategoryImage = item.CategoryImage
                };
                models.Add(model);
            }

            return models;
        }


    }


}