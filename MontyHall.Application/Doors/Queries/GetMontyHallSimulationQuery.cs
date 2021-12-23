using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MontyHall.Application.DoorCalculation;
using MontyHall.Application.Doors.Models;
namespace MontyHall.Application.Doors.Queries
{
    public class GetMontyHallSimulationQuery : IRequest<SimulationReplyModel>
    {
        public SimulationRequestModel GetRequestSimulations { get; set; }

        public class GetMontyHallSimulationQueryHandler : IRequestHandler<GetMontyHallSimulationQuery, SimulationReplyModel>
        {
            private readonly ICalculateDoors _calculateDoors;

            public GetMontyHallSimulationQueryHandler(ICalculateDoors calculateDoors)
            {
                _calculateDoors = calculateDoors;
            }
            public Task<SimulationReplyModel> Handle(GetMontyHallSimulationQuery request, CancellationToken cancellationToken)
            {
                var result = _calculateDoors.SimulateMontyHallGame(request.GetRequestSimulations.Simulations, request.GetRequestSimulations.IsSwitchedDoor);

                return Task.FromResult(result);
            }
        }
    }
}

