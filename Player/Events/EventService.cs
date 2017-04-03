using System.Collections.Generic;
using System.Linq;

namespace Player.Events
{
    public class EventService
    {
        public List<EventCollection> EventCollections { get; set; }

        public EventService()
        {
            EventCollections = new List<EventCollection>()
            {
                new EventCollection
                {
                    new Chest()
                }
            };

            ItemManager.Items.Add(
                1,
                new Item
                {
                    Id = 1,
                    Name = "Small HP potion",
                    Description = "Small HP potion, heals 10 HP",
                    ItemType = ItemType.Useable,
                    ImageKey = "icons",
                    SourceRect = new Rect(8 * 34, 4 * 34, 34, 34),
                    ItemActionType = ItemActionType.ModifyAttribute,
                    Quantity = 10,
                    Value = 50
                }
            );
        }

        public EventCollection Find(int i)
        {
            return EventCollections.Where(n => n.Id == i).FirstOrDefault();
        }
    }
}