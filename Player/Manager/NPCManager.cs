using Player.Effect;
using Player.Graphics;
using System.Collections.Generic;

namespace Player.Manager
{
    public class NPCManager
    {
        private readonly IActorManager _actorManager;
        private readonly IDialogManager _dialogManager;
        private readonly IGraphics _graphics;

        public NPCManager(IActorManager actorManager, IDialogManager dialogManager, IGraphics graphics)
        {
            _actorManager = actorManager;
            _dialogManager = dialogManager;
            _graphics = graphics;
        }

        public void Update(MapEngine map)
        {
            if (map.MapMeta.NPCs == null)
                return;

            foreach (var npc in map.MapMeta.NPCs)
                npc.Update(map);
        }

        public void Draw(MapEngine map)
        {
            if (map.MapMeta.NPCs == null)
                return;

            foreach (var npc in map.MapMeta.NPCs)
            {
                npc.Animation.Y = (int)npc.Direction;

                var pos = npc.Pos - map.Camera;

                _actorManager.Draw(npc.CharSet, npc.Animation.SourceRect, npc.Animation.DrawRect(pos));
            }
        }

        public List<IEffect> CheckTalk(MapEngine map, VectorF pos)
        {
            var npcs = map.MapMeta.NPCs;
            if (npcs == null)
                return null;

            var effects = new List<IEffect>();

            foreach (var npc in npcs)
            {
                if (Vector.Distance(npc.Pos, pos.ToVector()) < map.TileWidth + map.TileHeight)
                     effects.Add(new DialogEffect(_graphics, _dialogManager, npc.Dialog));
            }

            return effects;
        }
    }
}