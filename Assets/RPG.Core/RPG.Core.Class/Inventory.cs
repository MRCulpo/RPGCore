using System;
using System.Collections.Generic;


namespace RPG.Lite
{
    [System.Serializable]
    public class Inventory
    {
        public List<Item> item;

        public Inventory()
        {
            this.init();
        }
        public void init()
        {
            this.item = new List<Item>();
        }
        public void addItemInventory(Item _item)
        {
            this.item.Add(_item);
        }
        public void addItemInventory(List<Item> _items)
        {
            this.item.AddRange(_items);
        }

        public Item getItemIdObject(int _id)
        {
            foreach(Item _item in item)
            {
                if(_item.id == _id)
                {
                    return _item;
                }
            }
            return null;
        }

        public bool deleteItemIdObject(int _id)
        {
            foreach (Item _item in item)
            {
                if (_item.id == _id)
                {
                    item.Remove(_item);
                    return true;
                }
            }
            return false;
        }
    }
}
