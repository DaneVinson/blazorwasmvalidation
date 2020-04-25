using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PubsAndBeersDomain
{
    public interface IPubsService
    {
        Task<Pub> GetPub(int id);

        Task<IEnumerable<Pub>> GetPubs();
    }
}
