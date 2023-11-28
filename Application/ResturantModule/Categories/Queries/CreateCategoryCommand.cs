using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Application.Common.Interfaces;
using Domain.Entities.Common;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.ResturantModule.Categories.GetCategory
{
 

 public class GetCategoryCommand: IRequest<List<Category>>
 {

 }

 
 public class GetCategoryCommandHandler: IRequestHandler<GetCategoryCommand, List<Category>>
 {
    public readonly IApplicationDbContext _context;
    
    public GetCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

        public async Task<List<Category>> Handle(GetCategoryCommand request, CancellationToken cancellationToken)
        {
            List<Category> result = await _context.Categories.AsNoTracking().ToListAsync();
            return result;
        }

        
    }


}