using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PubsAndBeersDomain
{
    public class Beer
    {
        [Range(0.1, 99)]
        public double Abv { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Style { get; set; }


        public override string ToString()
        {
            return $"{Name}, {Style}, {Abv.ToString("#0.0")} ABV";
        }
    }

    public class BeerValidator : AbstractValidator<Beer>, IValidator<Beer>
    {
        public BeerValidator()
        {
            RuleFor(beer => beer.Abv)
                .Must(abv => abv >= 0.1 && abv < 99)
                .WithMessage("ABV must be within reasonable values");
            RuleFor(beer => beer.Name)
                .NotEmpty()
                .WithMessage("A Beer must have a name");
            RuleFor(beer => beer.Style)
                .NotEmpty()
                .WithMessage("A Beer must have a style");
        }
    }
}
