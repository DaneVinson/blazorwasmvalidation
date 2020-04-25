using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubsAndBeersDomain
{
    public class PubsService : IPubsService
    {
        public PubsService()
        {
            Pubs = new List<Pub>()
            {
                new Pub()
                {
                    Id = 1,
                    Name = "Lucky Lab Quimby",
                    Rank = 5,
                    OnTap = new List<Beer>()
                    {
                        new Beer() { Abv = 6.8, Name = "Black Sheep", Style = "CDA" },
                        new Beer() { Abv = 6.6, Name = "Super Dog", Style = "IPA" },
                        new Beer() { Abv = 5.4, Name = "Koenig's Kolsch", Style = "Kolsch" },
                        new Beer() { Abv = 5.1, Name = "Czech Pilsner", Style = "Pilsner" }
                    }
                },
                new Pub()
                {
                    Id = 2,
                    Name = "Craft Pour House",
                    Rank = 4,
                    OnTap = new List<Beer>()
                    {
                        new Beer() { Abv = 6.7, Name = "Breakside IPA", Style = "IPA" },
                        new Beer() { Abv = 5.8, Name = "Black Butte Porter", Style = "Porter" },
                        new Beer() { Abv = 5.2, Name = "1811 Lager", Style = "Lager" }
                    }
                },
                new Pub()
                {
                    Id = 3,
                    Name = "Nebulous Tap Room",
                    Rank = 4,
                    OnTap = new List<Beer>()
                    {
                        new Beer() { Abv = 4.0, Name = "Neverending Haze", Style = "Hazy Session IPA" },
                        new Beer() { Abv = 9.0, Name = "Old Rasputin", Style = "Russian Imperial Stout" },
                        new Beer() { Abv = 6.8, Name = "Topcutter", Style = "IPA" }
                    }
                },
                new Pub()
                {
                    Id = 4,
                    Name = "Vertigo Brewing",
                    Rank = 4,
                    OnTap = new List<Beer>()
                    {
                        new Beer() { Abv = 5.3, Name = "Razz Wheat", Style = "Wheat Ale" },
                        new Beer() { Abv = 6.1, Name = "Friar Mike's", Style = "IPA" },
                        new Beer() { Abv = 5.1, Name = "Tropical \"Key Lime\" Blonde Ale", Style = "Blonde Ale" },
                        new Beer() { Abv = 5.3, Name = "Smokestack Red", Style = "American Red Ale" }
                    }
                }
            };
        }


        public Task<Pub> GetPub(int id)
        {
            return Task.FromResult(Pubs.FirstOrDefault(p => p.Id == id));
        }

        public Task<IEnumerable<Pub>> GetPubs()
        {
            return Task.FromResult(Pubs.AsEnumerable());
        }


        private readonly List<Pub> Pubs;
        private readonly Random Random = new Random();
    }
}
