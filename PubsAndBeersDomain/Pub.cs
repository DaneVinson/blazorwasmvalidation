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
}
