using textor.models;
using textor.utils;
using System.Collections.Generic;
using System;
using System.Linq;

namespace textor.services 
{
    public partial class RoomService 
    {
        private List<Direction> _allDirections = new List<Direction>() {
            Direction.East,
            Direction.NorthEast, 
            Direction.West, 
            Direction.NorthWest, 
            Direction.North,
            Direction.South,
            Direction.SouthEast,
            Direction.SouthWest
        };

        private RoomProviderService _rps = new RoomProviderService();
        private DirectionUtils _du = new DirectionUtils();
        private readonly InventoryService _inventoryService;
        public RoomService(RoomId firstRoom, InventoryService inventoryService)
        {
            MoveToRoom(firstRoom);
            _inventoryService = inventoryService;
        }
        private Room _currentRoom;
        

        public void DescribeCurrentRoom() {
            Console.WriteLine(_currentRoom.LongDescription);
            Console.Write("In the room, there is ");
            List<string> nameStrings = new List<string>();
            foreach (var o in _currentRoom.Objects) {
                nameStrings.Add($"{o.Article} {o.Name}");
            }
            Console.Write(string.Join(',', nameStrings.Take(nameStrings.Count-1)));
            if (nameStrings.Count >= 2)
                Console.Write(" and " + nameStrings[nameStrings.Count-1]);
            else if (nameStrings.Count == 1) {
                Console.Write(nameStrings[0]);
            }
            Console.WriteLine(string.Empty);
            foreach (var exit in _currentRoom.Exits)
            {
                var room = _rps.GetRoom(exit.Room);
                Console.WriteLine($" to the {_du.GetNameForDirection(exit.Direction)} is {room.Article} {room.Name}");
            }
            
        }

        public void MoveToRoom(RoomId id) {
            _currentRoom = _rps.GetRoom(id);
            if (!_currentRoom.HasBeenEntered) {
                _currentRoom.OnFirstEntering();
            }
            _currentRoom.HasBeenEntered = true;
            DescribeCurrentRoom();
        }

        public void MoveToRoom(string input){
            var rooms = _currentRoom.Exits.Select(e => _rps.GetRoom(e.Room));
            var roomToMoveTo = _rps.Rooms.FirstOrDefault(r => input.ToLower().Contains(r.Name.ToLower()));
            if (roomToMoveTo == default) {
                
                throw new ArgumentException("Could not find room");
            }
            _currentRoom = roomToMoveTo;
            DescribeCurrentRoom();
        }

        public void Open(string input){
            List<Container> containersInRoom = _currentRoom.Objects.
                Where(o => o is Container).ToList().Cast<Container>().ToList();
            var container = containersInRoom.FirstOrDefault(c => input.Contains(c.Name));
            if (container == default){
                return;
            }
            
            while (true) {
                Console.WriteLine($"{container.Name} contents:");
                for (int i = 0; i < container.Items.Count(); i++) {
                    Console.WriteLine($"{i}: {container.Items[i].Name}");
                }
                Console.WriteLine("a: take all");
                Console.WriteLine("c: close container");
                Console.WriteLine(" >> ");
                var userInput = Console.ReadLine();

                if (userInput.ToLower().Contains("c")) {
                    return;
                }
                else if (userInput.ToLower().Contains("a")) {
                    foreach (var item in container.Items) {
                        _inventoryService.Inventory.Add(item);
                    }
                    container.Items = new List<Item>();
                }
                else if (Int32.TryParse(userInput, out int selection)) {
                    _inventoryService.Inventory.Add(container.Items[selection]);
                    container.Items = container.Items.Where(i => container.Items[selection].Name != i.Name).ToList();
                }
            }
        }
    }
}
