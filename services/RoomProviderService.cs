using System.Collections.Generic;
using System;
using System.Linq;
using textor.models;

namespace textor.services
{
    public class RoomProviderService
    {
        private readonly GameObjectProviderService _gop = new GameObjectProviderService();
        public List<Room> Rooms => new List<Room>()
            {
                new Room(
                    RoomId.EndarSpire_Quarters,
                    "QUARTERS",
                    "your",
                     "Your Sleeping Quarters on the Endar Spire",
                     "There is large window facing into the vacuum of space. " +
                     "around you is yours and your crewmate's bunks, and there is a small recreational area in the corner of the room.",
                     new List<Exit>() {
                        new Exit(RoomId.EndarSpire_QuartersCorridor, Direction.South)
                    },
                    new List<GameObject>() {
                        new Container() {
                             Name = "Footlocker",
                             Description = "A flat, durasteel footlocker",
                             Article = "a",
                             Items = new List<Item>() {_gop.GetItem(GameObjectId.short_sword)}
                        },
                    },
                    () => {
                            Console.WriteLine(@"You awake in your bunk to the sound of an explosion.");
                            return true;
                          }
                ),
                new Room(
                    RoomId.EndarSpire_QuartersCorridor,
                     "CORRIDOR",
                     "a",
                     "The Corridor leading from your Sleeping Quaters to the rest of the ship",
                     "This is a badly damaged ship corridor, various panels have been blown off the wall, "+
                     "And loose electricals spark and sizzle in the open air.",
                     new List<Exit>() {
                        new Exit(RoomId.EndarSpire_Quarters, Direction.North)
                    },
                    new List<GameObject>(),
                    () => {return true;}
                )
            };

            public Room GetRoom(RoomId id) {
            var room = Rooms.Where(r => r.Id == id).FirstOrDefault();
            if (room == default){
                throw new System.ArgumentException("The requested room could not be found");
            }
            return room;
        }
    }
}