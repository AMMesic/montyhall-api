using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MontyHall.API.Models;
using MontyHall.Application.Doors;
using MontyHall.Application.Doors.Models;
using MontyHall.Application.Doors.Queries;

namespace MontyHall.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MontyHallGameController : ControllerBase
    {
        private readonly ILogger<MontyHallGameController> _logger;
        private IMediator _mediator;
        public MontyHallGameController(ILogger<MontyHallGameController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("doors/{id}")]
        public async Task<ActionResult<IEnumerable<DoorModel>>> Get(int id)
        {
            DoorRequestModel doorRequestModel = new DoorRequestModel(id);

            var result = await _mediator.Send(new GetMontyHallDoorsQuery { GetDoorRequestModel = doorRequestModel });

            if(result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("simulation/{simulations}/{choiceofdoor}")]
        public async Task<ActionResult<SimulationReplyModel>> GetSimulation(int simulations, bool choiceOfDoor)
        {
            SimulationRequestModel requestModel = new SimulationRequestModel(
            
                simulations,
                choiceOfDoor
            );
            
            var result = await _mediator.Send(new GetMontyHallSimulationQuery { GetRequestSimulations = requestModel });

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }


    }
}

