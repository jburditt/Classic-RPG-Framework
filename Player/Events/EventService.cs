using Common;
using System.Collections.Generic;

namespace Player.Events
{
    public class EventService
    {
        private Dictionary<int, EventCollection> EventCollections { get; set; } = new Dictionary<int, EventCollection>();
        private SparseMatrix<int> Events { get; set; }

        public EventService()
        {
            var chest = new EventCollection { new Chest() };
            EventCollections.Add(1, chest);

            var warp = new EventCollection { new Warp() };
            EventCollections.Add(2, warp);

            var e3 = new EventCollection { new TentWarp() };
            EventCollections.Add(3, e3);

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

        public EventCollection Get(int x, int y)
        {
            return EventCollections[Events[x, y]];
        }
    }
}