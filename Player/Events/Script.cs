using Player.Effect;
using Player.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Player.Events
{
    [Serializable]
    public class Script
    {
        public static void Execute(EventPage eventPage, GamePlayer player, WorldState worldState, IGraphics graphics, IDialogManager dialog)
        {
            foreach (var script in eventPage.ScriptActionCollection)
            {
                switch (script.ScriptActionType) {

                    case ScriptActionType.ChangeItem:
                        var itemId = (int)script.Params[0];
                        player.ChangeItem(itemId, (int)script.Params[1]);
                        worldState.Effects.Add(new DialogEffect(graphics, dialog, $"Item {ItemManager.Items[itemId].Name} acquired."));
                        break;
                    case ScriptActionType.ChangeSelfSwitch:
                        eventPage.Switch.Set(script.Params[0].ToString(), (int)script.Params[1]);
                        break;
                    case ScriptActionType.ChangeMap:
                        worldState.Map.Load(script.Params[0].ToString());
                        player.Pos = new VectorF((int)script.Params[1] * worldState.Map.TileWidth, (int)script.Params[2] * worldState.Map.TileHeight);
                        break;
                }
            }
        }
    }

    [Serializable]
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

    [Serializable]
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
        ChangeSelfSwitch,
        ChangeMap
    }
}