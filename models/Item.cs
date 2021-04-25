using System.Collections.Generic;

namespace textor.models 
{
    public class Item : GameObject
    {
        public Item(GameObjectId id, string name, string description, string article) :
            base(id, name, description, article) {
        }
    }

    public class EquipableItem : Item 
    {
        public EquipableItem(GameObjectId id, string name, string description, string article, List<BodyPart> equipableOn) 
            : base (id, name, description, article) {
            EquipableOn = equipableOn;
        }
        public List<BodyPart> EquipableOn {get; set;}
    }

    public class UseableItem : Item
    {
        public UseableItem(GameObjectId id, string name, string description, string article) : base (id, name, description, article) 
        {
            
        }
    }
}