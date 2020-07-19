using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using PubsAndBeersDomain;

namespace PubsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PubsController : ControllerBase
    {
        private readonly IPubsService _pubsService;
        private readonly AbstractValidator<Pub> _pubValidator;

        public PubsController(IPubsService pubsService, AbstractValidator<Pub> pubValidator)
        {
            _pubsService = pubsService;
            _pubValidator = pubValidator;
        }

        [HttpGet]
        public Task<IEnumerable<Pub>> GetPubsAsync()
        {
            return _pubsService.GetPubs();
        }

        [HttpPost]
        public async Task<ActionResult<Pub>> CreatePub([FromBody]Pub pub)
        {
            var validationResult = await _pubValidator.ValidateAsync(pub);
            if (validationResult.IsValid)
            {
                return Ok(pub);
            }
            else
            {
                return new BadRequestObjectResult(validationResult.Errors);
            }
        }
    }
}
