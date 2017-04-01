using System.Collections.Generic;

namespace Player.Manager
{
    public class NPCManager
    {
        private IActorManager _actorManager;

        public List<NPC> NPC { get; set; }

        public NPCManager(IActorManager actorManager)
        {
            _actorManager = actorManager;
        }

        public void Draw(Map map, int playerX, int playerY)
        {
            foreach (var npc in NPC)
            {
                npc.animation.Y = (int)npc.direction;

                var pos = npc.Pos - map.Camera;

                _actorManager.Draw(npc.CharSet, npc.animation.DrawRect(pos.X, pos.Y), npc.animation.SourceRect);
            }
        }
    }
}