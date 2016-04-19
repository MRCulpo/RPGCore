using System;
using System.Collections.Generic;


namespace RPG.Lite
{
    [System.Serializable]
    public class Weapon : Item
    {
        public Damage damage;
        public Attributes attributes;
        public _Element element;
        public _Weapon typeWeapon;

        public Weapon()
        {
            this.id = 0;
            this.amount = 0;
            this.image = "";
            this.name = "";
            this.typeItem = _Item.Null;

            this.element = _Element.Null;
            this.typeWeapon = _Weapon.Null;
            this.damage = new Damage();
            this.attributes = new Attributes();
        }

        public Weapon(Weapon _weapon)
        {
            this.id = _weapon.id;
            this.amount = _weapon.amount;
            this.image = _weapon.image;
            this.name = _weapon.name;
            this.typeItem = _weapon.typeItem;

            this.element = _weapon.element;
            this.typeWeapon = _weapon.typeWeapon;
            this.damage = new Damage(_weapon.damage);
            this.attributes = new Attributes(_weapon.attributes);
        }

        public void addWeapon(Weapon _weapon)
        {
            this.element = _weapon.element;
            this.typeWeapon = _weapon.typeWeapon;
            this.damage += _weapon.damage;
            this.attributes += _weapon.attributes;
            //this.damage.addDamage(_weapon.damage);
            //this.attributes.addAttributes(_weapon.attributes);
        }

        public void removeWeapon(Weapon _weapon)
        {
            this.element = _Element.Null;
            this.typeWeapon = _Weapon.Null;

            this.damage -= _weapon.damage;
            this.attributes -= _weapon.attributes;

            /*
            this.damage.removeDamage(_weapon.damage);
            this.attributes.removeAttributes(_weapon.attributes);*/
        }
    }
}
