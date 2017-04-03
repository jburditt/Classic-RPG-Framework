using System.Collections.Generic;
using System.Linq;

namespace Player.Events
{
    public class EventService
    {
        private List<EventCollection> EventCollections { get; set; } = new List<EventCollection>();

        public EventService()
        {
            var chest = new EventCollection { new Chest() };
            chest.Id = 1;
            EventCollections.Add(chest);

            var warp = new EventCollection { new Warp() };
            warp.Id = 2;
            EventCollections.Add(warp);

            var e3 = new EventCollection { new TentWarp() };
            e3.Id = 3;
            EventCollections.Add(e3);

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