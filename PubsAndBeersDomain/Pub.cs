using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PubsAndBeersDomain
{
    public class Pub
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ValidateComplexType]
        public List<Beer> OnTap { get; set; } = new List<Beer>();

        [Range(1, 5)]
        public int Rank { get; set; }


        public override string ToString()
        {
            return $"{Name} (Rank: {Rank} / 5), {OnTap.Count} beers on tap";
        }
    }


    public class PubValidator : AbstractValidator<Pub>, IValidator<Pub>
    {
        public PubValidator(AbstractValidator<Beer> beerValidator)
        {
            RuleFor(pub => pub.Id)
                .Must(id => id > 0 && id < int.MaxValue)
                .WithMessage("Id must be an integer greater than 0");
            RuleFor(pub => pub.Name)
                .NotEmpty()
                .WithMessage("A Pub must have a name");
            RuleFor(pub => pub.Rank)
                .Must(rank => rank > 0 && rank < 6)
                .WithMessage("Rank must be between 1 and 5");
            RuleForEach(pub => pub.OnTap)
                .Must(beer => beerValidator.Validate(beer).IsValid);
        }
    }
}
