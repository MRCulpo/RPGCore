using System;
using System.Collections.Generic;


namespace RPG.Lite
{
    [System.Serializable]
    public class Utilities : Item
    {
        public float value;
        public Utilities() { }
        public Utilities(Utilities utilities)
        {
            this.value = utilities.value;
            this.id = utilities.id;
            this.amount = utilities.amount;
            this.image = utilities.image;
            this.name = utilities.name;
            this.desc = utilities.desc;
            this.typeItem = utilities.typeItem;
        }

        public Utilities(float value, int id, int amount, string img, string name, string desc, _Item typeItem)
        {
            this.value = value;
            this.id = id;
            this.amount = amount;
            this.image = img;
            this.name = name;
            this.desc = desc;
            this.typeItem = typeItem;
        }
    }
}
