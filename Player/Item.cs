namespace Player
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemType ItemType { get; set; }
        public ItemActionType ItemActionType { get; set; }
        public int Value { get; set; }
        public int Quantity { get; set; }
        //public TimeLapse TimeLapse { get; set; }
        public Rect SourceRect { get; set; }
        public string ImageKey { get; set; }
    }

    public enum ItemType
    {
        Useable,
        Equipment,
        Spell,
        Modifier
    }

    public enum ItemActionType
    {
        ModifyAttribute,
        Spell,
        Key
    }
}