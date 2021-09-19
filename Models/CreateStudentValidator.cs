using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationProject.Models
{
    public class CreateStudentValidator : AbstractValidator<CreateStudentViewModel>
    {
        public CreateStudentValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("نام نمی تواند خالی باشد");
        }
    }
}
