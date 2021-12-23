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
    public class GetMontyHallDoorsQuery : IRequest<IEnumerable<DoorModel>>
    {
        public DoorRequestModel GetDoorRequestModel { get; set; }
        

        public class GetMontyHallDoorsQueryHandler : IRequestHandler<GetMontyHallDoorsQuery, IEnumerable<DoorModel>>
        {
            private readonly ICalculateDoors _calculateDoors;

            public GetMontyHallDoorsQueryHandler(ICalculateDoors calculateDoors)
            {
                _calculateDoors = calculateDoors;
            }

            public Task<IEnumerable<DoorModel>> Handle(GetMontyHallDoorsQuery request, CancellationToken cancellationToken)
            {
                int _requestDoors = request.GetDoorRequestModel.DoorsRequest;
                var result = _calculateDoors.GetDoors(_requestDoors);

                return Task.FromResult(result);
            }
        }
    }
}

