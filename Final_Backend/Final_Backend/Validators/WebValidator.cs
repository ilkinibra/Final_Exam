using Final_Backend.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Backend.Validators
{
    public class WebValidator: AbstractValidator<Web>
    {
        public WebValidator()
        {
            RuleFor(w => w.ImageUrl).NotEmpty().NotNull();
            RuleFor(w => w.Title).NotNull().NotEmpty().MinimumLength(4);
            RuleFor(w => w.Description).NotNull().NotEmpty().MinimumLength(8);
        }
    }
}
