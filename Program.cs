using System;
using System.Linq;
using System.Collections.Generic;
using textor.services;
using textor.models;

namespace textor
{
    class Program
    {
        private static List<string> _moveToVerbs = new List<string>() {"move to", "go to"}; 

        static void Main(string[] args)
        {
            
            Console.WriteLine("----TEXTOR----");
            var roomService = new RoomService(RoomId.EndarSpire_Quarters); 
            while (true) {
                Console.WriteLine("\n");
                Console.Write(" >> ");
                var inputString = Console.ReadLine();
                if (_moveToVerbs.Any(v => inputString.ToLower().Contains(v.ToLower()))) {
                    roomService.MoveToRoom(inputString);
                }

            }

        }

       
    }
}
