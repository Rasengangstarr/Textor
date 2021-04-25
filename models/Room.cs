using System.Collections.Generic;
using System;

namespace textor.models {
    public class Room {
        public Room(RoomId id, string name, string article, string shortDescription, string longDescription, List<Exit> exits, List<GameObject> objects, Func<bool> onFirstEntering) {
            Id = id;
            
            LongDescription = longDescription;
            ShortDescription = shortDescription;
            Exits = exits;
            Objects = objects;
            Name = name;
            Article = article;
            OnFirstEntering = onFirstEntering;
        }

        public RoomId Id {get;}
        public string LongDescription {get;}
        public string ShortDescription {get;}
        public string Name {get;}
        public string Article {get;}
        public Func<bool> OnFirstEntering {get; set;}
        public bool HasBeenEntered {get; set;}

        public List<Exit> Exits {get;}
        public List<GameObject> Objects {get; set;}
    }

    public struct Exit {
        public Exit(RoomId id, Direction direction) {
            Room = id;
            Direction = direction;
        }
        public RoomId Room {get;}
        public Direction Direction {get;}

    }

}