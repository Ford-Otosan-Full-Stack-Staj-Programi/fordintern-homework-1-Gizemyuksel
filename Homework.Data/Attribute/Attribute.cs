using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Data.Attribute;

public class Attribute : AbstractValidator<Staff>
{
    public Attribute()
    {
        
        RuleFor(c => c.Id).NotEmpty().WithMessage("Please enter Id.");
        RuleFor(c => c.CreatedBy).NotEmpty().WithMessage("Please enter Created By.");
        RuleFor(c => c.CreatedAt).NotEmpty().WithMessage("Please enter Created At.");
        RuleFor(c => c.FirstName).NotEmpty().WithMessage("Please enter Firs tName.");
        RuleFor(c => c.LastName).NotEmpty().WithMessage("Please enter Last Name.");
        RuleFor(c => c.Email).NotEmpty().WithMessage("Please enter Email.");
        RuleFor(c => c.Phone).NotEmpty().WithMessage("Please enter Phone.");
        RuleFor(c => c.DateOfBirth).NotEmpty().WithMessage("Please enter Date O fBirth.");
        RuleFor(c => c.AddressLine1).NotEmpty().WithMessage("Please enter Adress Line.");
        RuleFor(c => c.City).NotEmpty().WithMessage("Please enter City.");
        RuleFor(c => c.Country).NotEmpty().WithMessage("Please enter Country.");
        RuleFor(c => c.Province).NotEmpty().WithMessage("Please enter Province.");
    }

}
