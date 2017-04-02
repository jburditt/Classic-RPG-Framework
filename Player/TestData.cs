using Player.Events;
using System.Collections.Generic;

namespace Player
{
    public class TestData
    {
        public List<EventCollection> EventCollections;
        public List<Item> Items;

        public TestData()
        {
            EventCollections = new List<EventCollection>()
            {
                new EventCollection
                {
                    new Chest()
                }
            };

            Items = new List<Item>
            {
                new Item {
                    Id = 1, Name = "Small HP potion", Description = "Small HP potion, heals 10 HP", ItemType = ItemType.Useable,
                    ImageKey = "icons", SourceRect = new Rect(8 * 34, 4 * 34, 34, 34), ItemActionType = ItemActionType.ModifyAttribute,
                    Quantity = 10, Value = 50
                }
            };
        }

        public class Chest : Event
        {
            public Chest()
            {
                EventPages = new List<EventPage> {
                    new EventPage {
                        ScriptActionCollection = new ScriptActionCollection
                        {
                            ScriptActions = new List<ScriptAction>
                            {
                                new ScriptAction(ScriptActionType.ChangeItem, 1, 1),
                                new ScriptAction(ScriptActionType.ChangeSelfSwitch, 1)
                            }
                        },
                        ImageKey = "icons",
                        ImageType = ImageType.Icon,
                        TilesetSource = new Rect(8 * 34, 4 * 34, 34, 34),
                        TriggerCollection = new TriggerCollection
                        {
                            Triggers = new List<Trigger>
                            {
                                new Trigger { TriggerType = TriggerType.SelfSwitch, Value = 0 }
                            }
                        }
                    },
                    new EventPage {
                        ScriptActionCollection = null,
                        ImageKey = "icons",
                        ImageType = ImageType.Icon,
                        TilesetSource = new Rect(9 * 34, 4 * 34, 34, 34),
                        TriggerCollection = new TriggerCollection
                        {
                            Triggers = new List<Trigger>
                            {
                                new Trigger { TriggerType = TriggerType.SelfSwitch, Value = 1 }
                            }
                        }
                    }
                };
            }
        }
    }
}