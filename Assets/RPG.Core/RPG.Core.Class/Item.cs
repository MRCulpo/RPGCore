using System;
using System.Collections.Generic;


namespace RPG.Lite
{
    [System.Serializable]
    public class Item
    {
        public int id;
        public int amount;
        public string image;
        public string name;
        public string desc;
        public _Item typeItem;
    }
}
