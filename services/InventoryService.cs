using System.Collections.Generic;
using textor.models;

namespace textor.services {
    public class InventoryService {
        public InventoryService() {
            Inventory = new List<Item>();
        }
        public List<Item> Inventory {get; set;}
    }    
}