using System.Collections.Generic;

namespace Player
{
    public class ItemManager
    {
        public static Dictionary<int, Item> Items { get; set; } = new Dictionary<int, Item>();

        public static Item CreateItem(int itemId, int quantity)
        {
            if (!Items.ContainsKey(itemId))
                return null;

            var item = Items[itemId];
            item.Quantity = quantity;

            return item;
        }
    }

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