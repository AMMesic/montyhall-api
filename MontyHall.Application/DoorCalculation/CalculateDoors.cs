using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MontyHall.Application.Doors.Models;

namespace MontyHall.Application.DoorCalculation
{
    public class CalculateDoors : ICalculateDoors
    {
        private Random _rand = new Random();
        private readonly ICalculateDoors _calculateDoors;
        public CalculateDoors()
        {
            _calculateDoors = this;
        }
        

        SimulationReplyModel ICalculateDoors.SimulateMontyHallGame(int simulations, bool isSwitchedDoor)
        {
            IEnumerable<DoorModel> doorModels = new List<DoorModel>();
            int wins = 0;
            for (int i = 0; i < simulations; i++)
            {
                int id = _rand.Next(1, 4);
                doorModels = _calculateDoors.GetDoors(3);
                
                var choosenDoor = doorModels.Where(x => x.Door == id).FirstOrDefault();
                doorModels = doorModels.Where(x => x.Door != choosenDoor.Door);

                if (!choosenDoor.Car)
                {
                    doorModels = doorModels.Where(x => x.Goat != true);
                }

                var switchedDoor = doorModels.FirstOrDefault();
                if (isSwitchedDoor == false)
                {
                    if (choosenDoor.Car == true)
                    {
                        wins++;
                    }
                }
                else
                {
                    if (switchedDoor.Car == true)
                    {
                        wins++;
                    }
                }

            }
            SimulationReplyModel replyModel = new SimulationReplyModel()
            {
                IsSwtichedDoor = isSwitchedDoor,
                Wins = wins
            };

            return replyModel;
        }

        IEnumerable<DoorModel> ICalculateDoors.GetDoors(int doors)
        {
            IEnumerable<DoorModel> doorModels = new List<DoorModel>();

            List<int> listOfDoors = getRandomDoors(doors);
            doorModels = GenerateDoors(listOfDoors);

            doorModels = doorModels.OrderBy(x => x.Door).ToList();

            return doorModels;
        }

        private List<int> getRandomDoors(int requestDoors)
        {
            List<int> listOfDoors = new List<int>();
            for (int i = 0; i < requestDoors; i++)
            {
                var randomDoor = _rand.Next(1, requestDoors + 1);
                while (listOfDoors.Where(x => x == randomDoor).Any())
                {
                    randomDoor = _rand.Next(1, requestDoors + 1);
                }
                listOfDoors.Add(randomDoor);
            }

            return listOfDoors;
        }

        private IEnumerable<DoorModel> GenerateDoors(List<int> listOfDoors)
        {
            List<DoorModel> doorModels = new List<DoorModel>();
            bool revealGoat = false;
            int carDoor = 0;
            bool isCar = true;

            foreach (var door in listOfDoors)
            {
                bool isCarOrGoat = Convert.ToBoolean(door);
                if (listOfDoors[0] == door)
                {
                    carDoor = listOfDoors.Select(x => x).FirstOrDefault();
                    doorModels.Add(new DoorModel
                    {
                        Car = isCar,
                        Goat = !isCar,
                        Door = door,
                        IsOpen = false,
                        RevealGoat = revealGoat
                    });
                }
                else
                {
                    if (doorModels.Where(x => x.Car == true).Any())
                    {
                        isCarOrGoat = !isCarOrGoat;
                    }

                    revealGoat = doorModels.Where(x => x.Goat == true && x.RevealGoat == false).Any() ? true : false;
                    doorModels.Add(new DoorModel
                    {
                        Car = false,
                        Goat = !isCarOrGoat,
                        Door = door,
                        IsOpen = false,
                        RevealGoat = revealGoat
                    });
                }
            }
            return doorModels;
        }
    }
}

