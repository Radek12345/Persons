using System.Collections.Generic;
using FluentValidation;
using Persons.Controllers.Resources;

namespace Persons.Controllers.Validators
{
    public class SaveOpinionResourceValidator : AbstractValidator<SaveOpinionResource>
    {
        private List<string> allowedInformation = new List<string> {
            "prasa",
            "telewizja",
            "znajomi",
            "inne"
        };

        public SaveOpinionResourceValidator()
        {
            RuleFor(reg => reg.OpinionText).NotEmpty();
            RuleFor(reg => reg.Rate).NotEmpty().InclusiveBetween(1, 5);
            RuleFor(reg => reg.Information).NotEmpty().Must(i => allowedInformation.Contains(i))
                .WithMessage("Specified 'information' is not alowed. Should entered: 'prasa', 'telewizja', 'znajomi' or 'inne'");
        }
    }
}