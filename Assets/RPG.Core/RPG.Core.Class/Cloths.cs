using System;
using System.Collections.Generic;


namespace RPG.Lite
{
    [System.Serializable]
    public class Clothes : Item
    {
        public Armor armor;
        public Attributes attributes;
        public _Cloths typeCloths;

        public Clothes() 
        {

            this.id = 0;
            this.amount = 0;
            this.image = "";
            this.name = "";
            this.typeItem = _Item.Null;

            this.armor = new Armor();
            this.attributes = new Attributes();
            this.typeCloths = _Cloths.Null;
        }

        public Clothes(Clothes _cloths)
        {
            this.id = _cloths.id;
            this.amount = _cloths.amount;
            this.image = _cloths.image;
            this.name = _cloths.name;
            this.typeItem = _cloths.typeItem;

            this.armor = new Armor(_cloths.armor);
            this.attributes = new Attributes(_cloths.attributes);
            this.typeCloths = _cloths.typeCloths;
        }

        public static Clothes operator +(Clothes _clothes1, Clothes _clothes2)
        {
            Clothes _clothes = new Clothes();

            _clothes.armor = _clothes1.armor + _clothes2.armor;
            _clothes.attributes = _clothes1.attributes + _clothes2.attributes;
            _clothes.typeCloths = _clothes2.typeCloths;

            return _clothes;
        }

        public static Clothes operator -(Clothes _clothes1, Clothes _clothes2)
        {
            Clothes _clothes = new Clothes();

            _clothes.armor = _clothes1.armor - _clothes2.armor;
            _clothes.attributes = _clothes1.attributes - _clothes2.attributes;
            _clothes.typeCloths = _clothes1.typeCloths;

            return _clothes;
        }

        public void addCloth(Clothes _cloths)
        {
            this.armor += _cloths.armor;
            this.attributes += _cloths.attributes;
            this.typeCloths = _cloths.typeCloths;

            //this.armor.addArmor(_cloths.armor);
            //this.attributes.addAttributes(_cloths.attributes);
            
        }

        public void removeCloths(Clothes _cloths)
        {
            this.armor -= _cloths.armor;
            this.attributes -= _cloths.attributes;

            //this.armor.removeArmor(_cloths.armor);
            //this.attributes.removeAttributes(_cloths.attributes);
        }

        public override string ToString()
        {
            return string.Format("[Cloths: armor={0}]", armor);
        }
    }
}
