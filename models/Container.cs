using System.Collections.Generic;

namespace textor.models 
{
    public class Container : GameObject
    {
        public Container(GameObjectId id, string name, string description, string article, List<Item> items) :
            base(id, name, description, article) {
                Items = items;
        }
        public List<Item> Items {get; set;}
    }
}