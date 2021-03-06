﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Player.Events
{
    [Serializable]
    public class EventCollection : IEnumerable<Event>
    {
        public int Id { get; set; }
        public List<Event> Events { get; set; } = new List<Event>();

        public void Add(Event e)
        {
            Events.Add(e);
        }

        public EventPage Action()
        {
            foreach (var n in this)
                foreach (var eventPage in n.EventPages)
                {
                    if (eventPage.Action())
                        return eventPage;
                }

            return null;
        }

        public EventPage Walk(bool on)
        {
            foreach (var n in this)
                foreach (var eventPage in n.EventPages)
                {
                    if (eventPage.Walk(on))
                        return eventPage;
                }

            return null;
        }

        public IEnumerator<Event> GetEnumerator()
        {
            return Events.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Event>)Events).GetEnumerator();
        }
    }

    [Serializable]
    public class Event
    {
        public List<EventPage> EventPages { get; set; }
    }

    [Serializable]
    public class EventPage
    {
        public SerializableDictionary<string, int> Switch { get; set; } = new SerializableDictionary<string, int>();
        public int Id { get; set; }
        public string ImageKey { get; set; }
        public ImageType ImageType { get; set; }
        public Rect TilesetSource { get; set; }
        public ScriptActionCollection ScriptActionCollection { get; set; }
        public TriggerCollection TriggerCollection { get; set; }

        public bool Action()
        {
            if (TriggerCollection == null)
                return false;

            return TriggerCollection.Action(this);
        }

        public bool Walk(bool on)
        {
            if (TriggerCollection == null)
                return false;

            return TriggerCollection.Walk(this, on);
        }
    }

    public enum ImageType
    {
        Icon,
        Tileset,
        Actor,
        BattleBg,
        BattleChar,
        Enemy
    }
}