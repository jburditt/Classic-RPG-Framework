using Player.Events;
using System;
using System.Collections.Generic;

namespace Player.Maps
{
    [Serializable]
    public class MapMeta
    {
        // TODO Make NPC Collection
        public IList<NPC> NPCs { get; set; }
        public IList<EventId> Events { get; set; }

         public void AddNPC(NPC n)
        {
            if (NPCs == null)
                NPCs = new List<NPC>();

            NPCs.Add(n);
        }

        public void AddEvent(EventId n)
        {
            if (Events == null)
                Events = new List<EventId>();

            Events.Add(n);
        }

        public NPC GetNPC(Vector pos)
        {
            if (NPCs == null)
                return null;

            foreach (var n in NPCs)
            {
                if (n.Pos == pos)
                    return n;
            }

            return null;
        }

        public EventId GetEventId(Vector pos)
        {
            if (Events == null)
                return null;

            foreach (var n in Events)
            {
                if (n.Pos == pos)
                    return n;
            }

            return null;
        }

        public void RemoveNPC(NPC npc)
        {
            NPCs.Remove(npc);
        }
    }
}