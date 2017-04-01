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

        public void Update(Map map)
        {
            foreach (var npc in NPC)
                npc.Update(map);
        }

        public void Draw(Map map)
        {
            foreach (var npc in NPC)
            {
                npc.Animation.Y = (int)npc.Direction;

                var pos = npc.Pos - map.Camera;

                _actorManager.Draw(npc.CharSet, npc.Animation.DrawRect(pos.X, pos.Y), npc.Animation.SourceRect);
            }
        }
    }
}