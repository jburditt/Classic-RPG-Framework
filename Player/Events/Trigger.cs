using System.Collections;
using System.Collections.Generic;

namespace Player.Events
{
    public class TriggerCollection : IEnumerable<Trigger>
    {
        public static SerializableDictionary<string, int> Switch { get; set; } = new SerializableDictionary<string, int>();

        public List<Trigger> Triggers { get; set; }

        #region IEnumerable
        public void Add(Trigger trigger)
        {
            Triggers.Add(trigger);
        }

        public IEnumerator<Trigger> GetEnumerator()
        {
            return Triggers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Trigger>)Triggers).GetEnumerator();
        }
        #endregion IEnumerable

        public bool Action(EventPage eventPage)
        {
            foreach (var trigger in this)
            {
                if (trigger.TriggerType == TriggerType.Action)
                    trigger.On = true;
            }

            return IsTriggered(eventPage);
        }

        public bool Walk(EventPage eventPage, bool on)
        {
            // TODO when you walk off the tile, trigger.On = false
            foreach (var trigger in this)
            {
                if (trigger.TriggerType == TriggerType.WalkOn)
                    trigger.On = on;
            }

            return IsTriggered(eventPage);
        }

        public bool IsTriggered(EventPage eventPage)
        {
            foreach (var trigger in Triggers)
            {
                switch (trigger.TriggerType)
                {
                    case TriggerType.Action:
                        if (!trigger.On)
                            return false;
                        break;

                    case TriggerType.SelfSwitch:

                        if (!eventPage.Switch.Is($"{trigger.EventPageId}", trigger.Value))
                            return false;
                        break;
                }
            }

            return true;
        }
    }

    public class Trigger
    {
        public int EventPageId { get; set; }
        public TriggerType TriggerType { get; set; }
        public string Key { get; set; }
        public int Value { get; set; }
        public bool On { get; set; }
    }

    public static class TriggerExtensions
    {
        public static bool Is(this Dictionary<string, int> Switch, string key, int value)
        {
            if (!Switch.ContainsKey(key))
                Switch[key] = 0;
            return (Switch[key] == value);
        }

        public static void Set(this Dictionary<string, int> Switch, string key, int value)
        {
            if (!Switch.ContainsKey(key))
                Switch[key] = 0;
            Switch[key] = value;
        }
    }

    public enum TriggerType
    {
        Action,
        Switch,
        SelfSwitch,
        WalkOn,
        Variable,
        Quest,
        Item,
        Actor
    }
}