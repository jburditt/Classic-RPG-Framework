using System.Collections;
using System.Collections.Generic;

namespace Player.Events
{
    public class EventCollection : IEnumerable
    {
        public List<Event> Events { get; set; }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Events.GetEnumerator();
        }

        public void Add(Event e)
        {
            Events.Add(e);
        }
    }

    public class Event
    {
        public List<EventPage> EventPages { get; set; }
    }

    public class EventPage
    {
        public string ImageKey { get; set; }
        public string ImageFolder { get; set; }
        public Rect TilesetSource { get; set; }
        public ScriptActionCollection ScriptActionCollection { get; set; }
        public TriggerCollection TriggerCollection { get; set; }
    }

    public class ScriptActionCollection
    {
        public List<ScriptAction> ScriptActions { get; set; }
    }

    public class ScriptAction
    {
        public ScriptAction(ScriptActionType actionType, params object[] p)
        {

        }
    }

    public class TriggerCollection
    {
        public List<Trigger> Triggers { get; set; }
    }

    public class Trigger
    {
        public TriggerType TriggerType { get; set; }
        public int Value { get; set; }
    }

    public enum ScriptActionType
    {
        ChangeItem,
        ChangeSelfSwitch
    }

    public enum TriggerType
    {
        Switch,
        SelfSwitch,
        Variable,
        Quest,
        Item,
        Actor
    }
}