﻿using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Validators
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Please enter the name.").NotNull().WithMessage("Please enter the name.");
            RuleFor(c => c.Email).NotEmpty().WithMessage("Please enter the email.").NotNull().WithMessage("Please enter the email.");
            RuleFor(c => c.Password).NotEmpty().WithMessage("Please enter the password.").NotNull().WithMessage("Please enter the password.");
        }
    }
}
