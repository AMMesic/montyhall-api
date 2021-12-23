using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MontyHall.Application.Doors.Models;

namespace MontyHall.Application.DoorCalculation
{
    public interface ICalculateDoors
    {
        public IEnumerable<DoorModel> GetDoors(int doors);
        public SimulationReplyModel SimulateMontyHallGame(int simulations, bool isSwitchedDoor);
    }
}

