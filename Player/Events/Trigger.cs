using System.Collections.Generic;

namespace Player.Events
{
    public class TriggerCollection
    {
        public static Dictionary<string, int> Switch { get; set; } = new Dictionary<string, int>();

        public List<Trigger> Triggers { get; set; }

        public bool IsTriggered()
        {
            foreach (var trigger in Triggers)
            {
                switch (trigger.TriggerType)
                {
                    case TriggerType.SelfSwitch:

                        if (Switch.ContainsKey("Self-" + trigger.Key) && Switch["Self-" + trigger.Key] != trigger.Value)
                            return false;
                        break;
                }
            }

            return true;
        }
    }

    public class Trigger
    {
        public TriggerType TriggerType { get; set; }
        public string Key { get; set; }
        public int Value { get; set; }
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