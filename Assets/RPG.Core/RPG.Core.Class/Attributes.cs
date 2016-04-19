using System;
using System.Collections.Generic;


namespace RPG.Lite
{
    [System.Serializable]
    public class Attributes
    {
        /// <summary>
        /// readonly VARIABLES
        /// </summary>
        private readonly int _Normalized = 1;
        private readonly int _NormalizedOther = 2;
        
        public int strength; 
        public int agility; 
        public int intelligence; 
        public int stamina;

        public Attributes()
        {
            this.strength = 0;
            this.agility = 0;
            this.intelligence = 0;
            this.stamina = 0;
        }
        public Attributes( Attributes _attributes )
        {
            this.strength = _attributes.stamina;
            this.agility = _attributes.agility;
            this.intelligence = _attributes.intelligence;
            this.stamina = _attributes.stamina;
            this._Normalized = 1;
            this._NormalizedOther = 2;
        }
        public Attributes(Attributes _attributes, int _normalized, int _normalizedOther)
        {
            this.strength = _attributes.stamina;
            this.agility = _attributes.agility;
            this.intelligence = _attributes.intelligence;
            this.stamina = _attributes.stamina;
            this._Normalized = _normalized;
            this._NormalizedOther = _normalizedOther;
        }

        public static Attributes operator + (Attributes _attributes1, Attributes _attributes2)
        {
            Attributes _attributes = new Attributes();

            _attributes.strength = _attributes1.strength + _attributes2.strength;
            _attributes.intelligence = _attributes1.intelligence + _attributes2.intelligence;
            _attributes.agility = _attributes1.agility + _attributes2.agility;
            _attributes.stamina = _attributes1.stamina + _attributes2.stamina;

            return _attributes;
        }

        public static Attributes operator - (Attributes _attributes1, Attributes _attributes2)
        {
            Attributes _attributes = new Attributes();

            _attributes.strength = _attributes1.strength - _attributes2.strength;
            _attributes.intelligence = _attributes1.intelligence - _attributes2.intelligence;
            _attributes.agility = _attributes1.agility - _attributes2.agility;
            _attributes.stamina = _attributes1.stamina - _attributes2.stamina;

            if (_attributes.strength <= 0) _attributes.strength = 0;
            if (_attributes.agility <= 0) _attributes.agility = 0;
            if (_attributes.intelligence <= 0) _attributes.intelligence = 0;
            if (_attributes.stamina <= 0) _attributes.stamina = 0;

            return _attributes;
        }

        public void addAttributes(Attributes _attributes)
        {
            this.strength += _attributes.stamina;
            this.agility += _attributes.agility;
            this.intelligence += _attributes.intelligence;
            this.stamina += _attributes.stamina;
        }
        public void removeAttributes(Attributes _attributes)
        {
            this.strength -= _attributes.stamina;
            this.agility -= _attributes.agility;
            this.intelligence -= _attributes.intelligence;
            this.stamina -= _attributes.stamina;

            if (this.strength <= 0) this.strength = 0;
            if (this.agility <= 0) this.agility = 0;
            if (this.intelligence <= 0) this.intelligence = 0;
            if (this.stamina <= 0) this.stamina = 0;
        }
        public void attributePerLevel(Class _class)
        {
            if( _class.typeClass == _Class.Warrior)
            {
                this.strength += _Normalized * _class.classModifier;
                this.stamina += _Normalized;
                this.intelligence += _Normalized;
                this.agility += _Normalized;
            }
            else if (_class.typeClass == _Class.Archer)
            {
                this.strength += _Normalized;
                this.stamina += _Normalized;
                this.intelligence += _Normalized;
                this.agility += _Normalized * _class.classModifier;
            }
            else if (_class.typeClass == _Class.Wizard)
            {
                this.strength += _Normalized;
                this.stamina += _Normalized;
                this.intelligence += _Normalized * _class.classModifier;
                this.agility += _Normalized;
            }
            else if (_class.typeClass == _Class.Priest)
            {
                this.strength += _Normalized;
                this.stamina += _Normalized;
                this.intelligence += _NormalizedOther * _class.classModifier;
                this.agility += _Normalized;
            }
        }

        public void removeEffects(_EffectsRemove _effects, int _value)
        {
            if (_effects == _EffectsRemove.Strength)
            {
                this.strength -= _value;
            }
            else if (_effects == _EffectsRemove.Stamina)
            {
                this.stamina -= _value;
            }
            else if (_effects == _EffectsRemove.Intelligence)
            {
                this.intelligence -= _value;
            }
            else if (_effects == _EffectsRemove.Agility)
            {
                this.agility -= _value;
            }
        }

        public void reverseEffects(_EffectsRemove _effects, int _value)
        {
            if (_effects == _EffectsRemove.Strength)
            {
                this.strength += _value;
            }
            else if (_effects == _EffectsRemove.Stamina)
            {
                this.stamina += _value;
            }
            else if (_effects == _EffectsRemove.Intelligence)
            {
                this.intelligence += _value;
            }
            else if (_effects == _EffectsRemove.Agility)
            {
                this.agility += _value;
            }
        }
    }
}
