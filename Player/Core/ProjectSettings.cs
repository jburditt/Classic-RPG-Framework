using DataStore;
using System;

namespace Player.Core
{
    public struct ProjectSettings : IModified
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime CreatedOn { get; }
        public DateTime LastModified { get; }
        public string StartMapId { get; set; }
        public Vector StartPos { get; set; }
        public string MenuBgId { get; set; }
        public string SongId { get; set; }
    }
}