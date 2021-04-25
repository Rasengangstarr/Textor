using System.Collections.Generic;

namespace textor.models 
{
    public class Character : GameObject 
    {
       public Character(GameObjectId id, string name, string description, string article, int strength,
       int dexterity, int constitution, int wisdom, int charisma) :
            base(id, name, description, article) {
                Strength = strength;
                Dexterity = dexterity;
                Constitution = constitution;
                Wisdom = wisdom;
                Charisma = charisma;
        }

        public void Equip(BodyPart slot, EquipableItem item)
        {
            switch(slot) {
                case BodyPart.Head:
                    Head = item;
                    return;
                case BodyPart.Body:
                    Body = item;
                    return;
                case BodyPart.Hands:
                    Hands = item;
                    return;
                case BodyPart.LeftHand:
                    LeftHand = item;
                    return;
                case BodyPart.RightHand:
                    RightHand = item;
                    return;
                case BodyPart.LeftArm:
                    LeftArm = item;
                    return;
                case BodyPart.RightArm:
                    RightArm = item;
                    return;
                case BodyPart.Belt:
                    Belt = item;
                    return;
                case BodyPart.Implant:
                    Implant = item;
                    return;
                default:
                    return;

            }
        }

        public int Strength {get; set;}
        public int Dexterity {get; set;}
        public int Constitution {get; set;}
        public int Wisdom {get; set;}
        public int Charisma {get; set;}

        public EquipableItem Head {get; set;}
        public EquipableItem LeftHand {get; set;}
        public EquipableItem RightHand {get; set;}
        public EquipableItem LeftArm {get; set;}
        public EquipableItem RightArm {get; set;}
        public EquipableItem Belt {get; set;}
        public EquipableItem Implant {get; set;}
        public EquipableItem Body {get; set;}
        public EquipableItem Hands {get; set;}

    }

    public class PartyMember : Character
    {
        public PartyMember(GameObjectId id, string name, string description, string article, int strength,
            int dexterity, int constitution, int wisdom, int charisma) 
            : base(id, name, description, article, strength, dexterity, constitution, wisdom, charisma){
                
            }
        
    }

    public class Enemy : Character
    {
        public Enemy(GameObjectId id, string name, string description, string article, int strength,
            int dexterity, int constitution, int wisdom, int charisma) 
            : base(id, name, description, article, strength, dexterity, constitution, wisdom, charisma){
                
            } 
            public List<Item> Inventory {get; set;} 
    }
    
}