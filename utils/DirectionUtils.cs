using textor.models;
using System;

namespace textor.utils {
    public class DirectionUtils {
        public string GetNameForDirection(Direction d) {
            switch (d) {
                case Direction.North:
                    return "NORTH";
                case Direction.NorthEast:
                    return "NORTH EAST";
                case Direction.East:
                    return "EAST";
                case Direction.SouthEast:
                    return "SOUTH EAST";
                case Direction.South:
                    return "SOUTH";
                case Direction.SouthWest:
                    return "SOUTH WEST";
                case Direction.West:
                    return "WEST";
                case Direction.NorthWest:
                    return "NORTH WEST";
                default:
                    throw new Exception();
            }
        }

        public Direction GetDirectionForName(string n) {
            n = n.ToUpper();
            switch (n) {
                case "NORTH":
                    return Direction.North;
                case "NORTH EAST":
                case "NORTHEAST":
                    return Direction.NorthEast; 
                case "EAST":
                    return Direction.East; 
                case "SOUTH EAST":
                case "SOUTHEAST":
                    return Direction.SouthEast; 
                case "SOUTH":
                    return Direction.South; 
                case "SOUTH WEST":
                case "SOUTHWEST":
                    return Direction.SouthWest; 
                case "WEST":
                    return Direction.West; 
                case "NORTH WEST":
                case "NORTHWEST":
                    return Direction.NorthWest;
                default:
                    throw new Exception();
            }
        }
    }
}