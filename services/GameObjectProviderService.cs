using textor.models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace textor.services 
{
    public class GameObjectProviderService 
    {
        public GameObjectProviderService() {
            AddContainers();
        }

        private void AddContainers()
        {
            AllObjects.AddRange(new List<Container> {
                 new Container(
                    GameObjectId.endarspire_quarters_footlocker,
                    "footlocker",
                    @"a long, hard cuboid object for storing stuff",
                    // metal rectangle roughly about a foot wide with a basic touch screen lock interface
                    "a",
                    new List<Item>() { GetObject(GameObjectId.clothing) as Item, GetObject(GameObjectId.short_sword) as Item} 
                )
            });
        }

        public List<GameObject> AllObjects =
            new List<GameObject>()
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
                new EquipableItem(
                    GameObjectId.clothing,
                    "clothing",
                    "These are simple garments that protect little more than the modesty of the wearer",
                    "some",
                    new List<BodyPart> () { BodyPart.Body }
                ),
               
            };

        public GameObject GetObject(GameObjectId id) => 
            AllObjects.FirstOrDefault(i => i.Id == id);
        
    }
}
