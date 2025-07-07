using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Application.Common.Interfaces;
using Domain.Entities.Common;
using FluentValidation;
using MediatR;

namespace Application.ResturantModule.Categories.CreateCategory
{
 

 public class CreateCategoryCommand: IRequest<int>
 {
     public int Id {get; set;}   
     public string? CategoryName {get; set;}
     public string? CategoryDescription {get; set;}
     public string? CategoryImage {get; set;}
 }

 
 public class CreateCategoryCommandHandler: IRequestHandler<CreateCategoryCommand,int>
 {
    public readonly IApplicationDbContext _context;
    public readonly IValidator<CreateCategoryCommand> _validator;
    public CreateCategoryCommandHandler(IApplicationDbContext context,IValidator<CreateCategoryCommand> validator)
    {
        _context = context;
        _validator = validator; 
    }

        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = new Category{
                CategoryName = request.CategoryName,
                CategoryDescription = request.CategoryDescription,
                CategoryImage = request.CategoryImage
            };

            //var results 

            await _context.Categories.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;

        }

        
    }


}