using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PubsAndBeersDomain;

namespace PubsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PubsController : ControllerBase
    {
        private readonly IPubsService _pubsService;

        public PubsController(IPubsService pubsService) => 
            _pubsService = pubsService;

        [HttpGet]
        public Task<IEnumerable<Pub>> GetPubsAsync()
        {
            return _pubsService.GetPubs();
        }

        [HttpPost]
        public ActionResult<Pub> CreatePub([FromBody]Pub pub)
        {
            return Ok(pub);
        }
    }
}
