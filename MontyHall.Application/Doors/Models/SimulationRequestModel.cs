using System;
using System.ComponentModel.DataAnnotations;

namespace MontyHall.Application.Doors.Models
{
    public class SimulationRequestModel
    {
        [Required]
        public int Simulations { get; set; }

        [Required]
        public bool IsSwitchedDoor { get; set; }

        public SimulationRequestModel(int simulations, bool isSwitcheddoor)
        {
            if (simulations < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(simulations), "Request cannot be less then 0");
            }

            if(string.IsNullOrEmpty(Convert.ToString(isSwitcheddoor)))
            {
                throw new ArgumentNullException(nameof(isSwitcheddoor), "Request cannot be null or anything else than bool");
            }

            Simulations = simulations;
            IsSwitchedDoor = isSwitcheddoor;
        }
    }
}

