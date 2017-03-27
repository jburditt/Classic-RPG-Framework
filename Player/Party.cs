using System;
using System.Collections.Generic;

namespace Player
{
    public class Party
    {
        public List<Actor> Actors = new List<Actor>();
        private int activeIndex;
        public Actor ActivePlayer
        {
            get
            {
                return Actors[activeIndex];
            }
            set
            {
                activeIndex = Actors.IndexOf(value);
            }
        }

        public Actor GetRandom()
        {
            if (Actors == null || Actors.Count == 0)
                return null;

            int n = new Random().Next(Actors.Count);
            return Actors[n];
        }
    }
}