using System.Collections;
using System.Collections.Generic;

namespace Player.Events
{
    public class Script
    {
        public static void Execute(EventPage eventPage, GamePlayer player, Map map)
        {
            foreach (var script in eventPage.ScriptActionCollection)
            {
                switch (script.ScriptActionType) {

                    case ScriptActionType.ChangeItem:
                        player.ChangeItem((int)script.Params[0], (int)script.Params[1]);
                        break;
                    case ScriptActionType.ChangeSelfSwitch:
                        eventPage.Switch.Set(script.Params[0].ToString(), (int)script.Params[1]);
                        break;
                }
            }
        }
    }

    public class ScriptActionCollection : IEnumerable<ScriptAction>
    {
        public List<ScriptAction> ScriptActions { get; set; }

        public void Add(ScriptAction scriptAction)
        {
            ScriptActions.Add(scriptAction);
        }

        public IEnumerator<ScriptAction> GetEnumerator()
        {
            return ScriptActions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<ScriptAction>)ScriptActions).GetEnumerator();
        }
    }

    public class ScriptAction
    {
        public ScriptActionType ScriptActionType { get; set; }
        public object[] Params { get; set; }

        public ScriptAction() { }

        public ScriptAction(ScriptActionType actionType, params object[] p)
        {
            ScriptActionType = actionType;
            Params = p;
        }
    }

    public enum ScriptActionType
    {
        ChangeItem,
        ChangeSelfSwitch
    }
}