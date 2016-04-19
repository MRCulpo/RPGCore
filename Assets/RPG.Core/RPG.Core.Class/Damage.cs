using System;
using System.Collections.Generic;


namespace RPG.Lite
{
    [System.Serializable]
    public class Damage : IEffects 
    {
        public int damage;
        public int criticalDamage;
        public int elementalDamage;

        public Damage()
        {
            this.damage = 0;
            this.criticalDamage = 0;
            this.elementalDamage = 0;
        }

        public Damage(Damage damage)
        {
            this.damage = damage.damage;
            this.criticalDamage = damage.criticalDamage;
            this.elementalDamage = damage.elementalDamage;
        }

        public static Damage operator +(Damage _damage1, Damage _damage2)
        {
            Damage _damage = new Damage();

            _damage.damage = _damage1.damage + _damage2.damage;
            _damage.criticalDamage = _damage1.criticalDamage + _damage2.criticalDamage;
            _damage.elementalDamage = _damage1.elementalDamage + _damage2.elementalDamage;

            return _damage;
        }

        public static Damage operator -(Damage _damage1, Damage _damage2)
        {
            Damage _damage = new Damage();

            _damage.damage = _damage1.damage - _damage2.damage;
            _damage.criticalDamage = _damage1.criticalDamage - _damage2.criticalDamage;
            _damage.elementalDamage = _damage1.elementalDamage - _damage2.elementalDamage;

            if (_damage.damage < 0) _damage.damage = 0;
            if (_damage.criticalDamage < 0) _damage.criticalDamage = 0;
            if (_damage.elementalDamage < 0) _damage.elementalDamage = 0;

            return _damage;
        }

        public void addDamage(Damage damage)
        {
            this.damage += damage.damage;
            this.criticalDamage += damage.criticalDamage;
            this.elementalDamage += damage.elementalDamage;
        }

        public void removeDamage(Damage damage)
        {
            this.damage -= damage.damage;
            this.criticalDamage -= damage.criticalDamage;
            this.elementalDamage -= damage.elementalDamage;

            if (this.damage < 0) this.damage = 0;
            if (this.criticalDamage < 0) this.criticalDamage = 0;
            if (this.elementalDamage < 0) this.elementalDamage = 0;
        }

        public void removeEffects(_EffectsRemove _effects, int _value)
        {
            if (_effects == _EffectsRemove.Damage)
            {
                this.damage -= _value;
            }
            else if (_effects == _EffectsRemove.CriticalDamage)
            {
                this.criticalDamage -= _value;
            }
            else if (_effects == _EffectsRemove.ElementalDamage)
            {
                this.elementalDamage -= _value;
            }
        }

        public void reverseEffects(_EffectsRemove _effects, int _value)
        {
            if (_effects == _EffectsRemove.Damage)
            {
                this.damage -= _value;
            }
            else if (_effects == _EffectsRemove.CriticalDamage)
            {
                this.criticalDamage -= _value;
            }
            else if (_effects == _EffectsRemove.ElementalDamage)
            {
                this.elementalDamage -= _value;
            }
        }

        public override string ToString()
        {
            return string.Format("[Damage: damage={0}, criticalDamage={1}, elementalDamage={2}]", damage, criticalDamage, elementalDamage);
        }
    }
}
