using textor.models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace textor.services 
{
    public class GameObjectProviderService 
    {
        public static List<Item> AllItems =>
            new List<Item>()
            {
                new EquipableItem(
                    GameObjectId.long_sword,
                    "long sword", 
                    @"Here is where the roots of the lightsaber begin, with traditional
                    swords still wielded today in many primitive cultures. They are simple,
                    but still effective in the right hands.",
                    "a",
                    new List<BodyPart>() { BodyPart.LeftArm, BodyPart.RightArm}
                ),
                new EquipableItem(
                    GameObjectId.short_sword,
                    "short sword", 
                    @"Disregarded by most modern warriors, a good short sword can still serve well
                     in combat if the user is skilled. ",
                    "a",
                    new List<BodyPart>() { BodyPart.LeftArm, BodyPart.RightArm}
                ),
            };

        public Item GetItem(GameObjectId id) => 
            AllItems.FirstOrDefault(i => i.Id == id);
        
    }
}
