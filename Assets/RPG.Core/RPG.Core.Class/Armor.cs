using System;
using System.Collections.Generic;


namespace RPG.Lite
{
    [System.Serializable]
    public class Armor : IEffects
    {
        public int armor;
        public int parry;
        public Resistance resistance;

        public Armor()
        {
            this.armor = 0;
            this.parry = 0;

            this.resistance = new Resistance();
        }

        public Armor(Armor armor)
        {
            this.armor = armor.armor;
            this.parry = armor.parry;

            this.resistance = new Resistance( armor.resistance);  
        }

        public static Armor operator + (Armor _armor1, Armor _armor2)
        {
            Armor _armor = new Armor();

            _armor.armor = _armor1.armor + _armor2.armor;
            _armor.parry = _armor1.parry + _armor2.parry;
            _armor.resistance = _armor1.resistance + _armor2.resistance;

            return _armor;
        }

        public static Armor operator - (Armor _armor1, Armor _armor2)
        {
            Armor _armor = new Armor();

            _armor.armor = _armor1.armor - _armor2.armor;
            _armor.parry = _armor1.parry - _armor2.parry;
           
            if (_armor.armor <= 0) _armor.armor = 0;
            if (_armor.parry <= 0) _armor.parry = 0;

            _armor.resistance = _armor1.resistance + _armor2.resistance;

            return _armor;
        }

        public void addArmor(Armor armor)
        {
            this.armor += armor.armor;
            this.parry += armor.parry;
            this.resistance += armor.resistance;
            //this.resistance.addResistence(armor.resistance);
        }

        public void removeArmor(Armor armor)
        {
            this.armor -= armor.armor;
            this.parry -= armor.parry;

            if (this.armor <= 0) this.armor = 0;
            if (this.parry <= 0) this.parry = 0;

            this.resistance -= armor.resistance;
            //this.resistance.removeResistence(armor.resistance);
        }

        public void removeEffects( _EffectsRemove _effects, int _value )
        {
            if(_effects == _EffectsRemove.Armor)
            {
                this.armor -= _value;
            }
            else if(_effects == _EffectsRemove.Parry)
            {
                this.parry -= _value;
            }
            else if(_effects == _EffectsRemove.Fire)
            {
                this.resistance.fire -= _value;
            }
            else if(_effects == _EffectsRemove.Frost)
            {
                this.resistance.frost -= _value;
            }
            else if(_effects == _EffectsRemove.Nature)
            {
                this.resistance.nature -= _value;
            }
            else if(_effects == _EffectsRemove.Dark)
            {
                this.resistance.dark -= _value;
            }
        }

        public void reverseEffects(_EffectsRemove _effects, int _value)
        {
            if (_effects == _EffectsRemove.Armor)
            {
                this.armor += _value;
            }
            else if (_effects == _EffectsRemove.Parry)
            {
                this.parry += _value;
            }
            else if (_effects == _EffectsRemove.Fire)
            {
                this.resistance.fire += _value;
            }
            else if (_effects == _EffectsRemove.Frost)
            {
                this.resistance.frost += _value;
            }
            else if (_effects == _EffectsRemove.Nature)
            {
                this.resistance.nature += _value;
            }
            else if (_effects == _EffectsRemove.Dark)
            {
                this.resistance.dark += _value;
            }
        }

        public override string ToString()
        {
            return string.Format("[Armor: armor={0}, parry={1}, resistance={2}]", armor, parry, resistance);
        }
    }
}
