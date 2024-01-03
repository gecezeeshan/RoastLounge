using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Application.Common.Interfaces;
using Domain.Entities.Common;
using FluentValidation;
using MediatR;

namespace Application.ResturantModule.Categories.CreateCategory
{
 

 public class CreateCategoryCommandValidator: AbstractValidator<CreateCategoryCommand>
 {
 public CreateCategoryCommandValidator()
 {
    
 }
 }

 
}