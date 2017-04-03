using Player.Events;
using System.Collections.Generic;

namespace Player
{
    public class Chest : Event
    {
        public Chest()
        {
            EventPages = new List<EventPage> {
                new EventPage {
                    Id = 1,
                    ScriptActionCollection = null,
                    ImageKey = "icons",
                    ImageType = ImageType.Icon,
                    TilesetSource = new Rect(7 * 34, 29 * 34, 34, 34),
                    TriggerCollection = null
                },
                new EventPage {
                    Id = 2,
                    ScriptActionCollection = new ScriptActionCollection
                    {
                        ScriptActions = new List<ScriptAction>
                        {
                            new ScriptAction(ScriptActionType.ChangeItem, 1, 1)
                        }
                    },
                    ImageKey = "icons",
                    ImageType = ImageType.Icon,
                    TilesetSource = new Rect(8 * 34, 29 * 34, 34, 34),
                    TriggerCollection = new TriggerCollection
                    {
                        Triggers = new List<Trigger>
                        {
                            new Trigger { TriggerType = TriggerType.Action, Value = 0 }
                        }
                    }
                }
            };
        }
    }

    public class Warp : Event
    {
        public Warp()
        {
            EventPages = new List<EventPage> {
                new EventPage {
                    Id = 3,
                    ScriptActionCollection = new ScriptActionCollection
                    {
                        ScriptActions = new List<ScriptAction>
                        {
                            new ScriptAction(ScriptActionType.ChangeMap, "Tent", 12, 22)
                        }
                    },
                    ImageKey = null,
                    ImageType = 0,
                    TilesetSource = new Rect(0, 0, 0, 0),
                    TriggerCollection = new TriggerCollection
                    {
                        Triggers = new List<Trigger>
                        {
                            new Trigger { TriggerType = TriggerType.WalkOn, Value = 0 }
                        }
                    }
                }
            };
        }
    }

    public class TentWarp : Event
    {
        public TentWarp()
        {
            EventPages = new List<EventPage> {
                new EventPage {
                    Id = 4,
                    ScriptActionCollection = new ScriptActionCollection
                    {
                        ScriptActions = new List<ScriptAction>
                        {
                            new ScriptAction(ScriptActionType.ChangeMap, "Start", 55, 59)
                        }
                    },
                    ImageKey = null,
                    ImageType = 0,
                    TilesetSource = new Rect(0, 0, 0, 0),
                    TriggerCollection = new TriggerCollection
                    {
                        Triggers = new List<Trigger>
                        {
                            new Trigger { TriggerType = TriggerType.WalkOn, Value = 0 }
                        }
                    }
                }
            };
        }
    }
}