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
}
