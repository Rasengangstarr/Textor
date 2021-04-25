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
        public RoomService(RoomId firstRoom)
        {
            MoveToRoom(firstRoom);
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
    }
}