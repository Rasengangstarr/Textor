using System;
using System.Linq;
using System.Collections.Generic;
using textor.services;
using textor.models;

namespace textor
{
    class Program
    {
        private static List<string> _moveToVerbs = new List<string>() {"cd", "move", "go"};
        private static List<string> _openVerbs = new List<string>() {"open", "loot"};
        private static List<string> _inventoryVerbs = new List<string>() {"items", "inventory"};
        private static List<Item> _playerInventory = new List<Item>();

        private static PartyMember _revan = new PartyMember(GameObjectId.revan, "player", "its you!", "the", 1,1,1,1,1);

        private static readonly InventoryService _inventoryService = new InventoryService();

        static void Main(string[] args)
        {
            
            Console.WriteLine("----TEXTOR----");
            var roomService = new RoomService(RoomId.EndarSpire_Quarters, _inventoryService); 
            while (true) {
                Console.WriteLine("\n");
                Console.Write(" >> ");
                var inputString = Console.ReadLine();
                if (_moveToVerbs.Any(v => inputString.ToLower().Contains(v.ToLower()))) {
                    roomService.MoveToRoom(inputString);
                }
                if (_openVerbs.Any(v => inputString.ToLower().Contains(v.ToLower()))) {
                    roomService.Open(inputString);
                }

                //TODO: THIS IS NOT PRODUCTION CODE
                if (inputString.Contains("equipment")) {
                    Console.WriteLine($"BODY: {_revan.Body.Name}");
                    Console.WriteLine($"LEFT HAND: {_revan.LeftHand.Name}");
                    Console.WriteLine($"RIGHT HAND: {_revan.RightHand.Name}");
                }
                if (_inventoryVerbs.Any(v => inputString.ToLower().Contains(v.ToLower()))) {
                    Console.WriteLine("Inventory:");
                    for (int i = 0; i < _inventoryService.Inventory.Count(); i++)
                    {
                        Console.WriteLine($"{i}:{_inventoryService.Inventory[i].Name}");
                    }
                    Console.WriteLine("c: cancel");
                    var inventoryInput = Console.ReadLine();

                    if (inventoryInput.ToLower().Contains("c")) {
                        return;
                    }

                    if (Int32.TryParse(inventoryInput, out int selection)) {
                        if (_inventoryService.Inventory[selection] is EquipableItem) {
                            EquipableItem item = _inventoryService.Inventory[selection] as EquipableItem;
                            Console.WriteLine("which party member do you want to give this item to?");
                            //TODO: select the party member
                            Console.WriteLine("which slot do you want to equip it in?");

                            Console.WriteLine(">>");

                            for(int i = 0; i < item.EquipableOn.Count(); i++) {
                                Console.WriteLine($"{i}: {item.EquipableOn[i]}");
                            }
                            Console.WriteLine("c: cancel");
                            var slotInput = Console.ReadLine();

                            if (inventoryInput.ToLower().Contains("c")) {
                                return;
                            }
                            
                            if (Int32.TryParse(slotInput, out int slotSelection)) {
                                _revan.Equip((BodyPart)slotSelection, item);
                                _inventoryService.Inventory = _inventoryService.Inventory.Where(i => i.Id != item.Id).ToList();
                            }
                        }
                    }


                }
            }

        }


    }
}
