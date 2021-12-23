using System;
using System.ComponentModel.DataAnnotations;

namespace MontyHall.Application.Doors.Models
{
    public class DoorRequestModel
    {
        [Required]
        public int DoorsRequest { get; set; }

        public DoorRequestModel(int doorsRequest)
        {
            if (doorsRequest < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(doorsRequest), "Request cannot be less than 0");
            }

            DoorsRequest = doorsRequest;
        }
    }
}

