using System;
using System.Collections.Generic;


namespace RPG.Lite
{
    [System.Serializable]
    public class Life : IEffects
    {
        public int currentLife;                   //corresponde a vida atual
        public int life;                          //corresponde a vida total 

        public Life()
        {
            this.currentLife = 0;
            this.life = 0;
        }

        public Life (Life _life)
        {
            this.currentLife = _life.currentLife;
            this.life = _life.life;
        }

        public void addPointLife(int _life)
        {
            this.life += life;
        }

        public void removePointLife(int _life)
        {
            this.life -= _life;
            if (this.life <= 0)
                this.life = 0;
        }

        public void addlife(int _currentLife)
        {
            this.currentLife += _currentLife;

            if (this.currentLife >= this.life)
                this.currentLife = this.life;
        }

        public void removeLife(int _currentLife)
        {
            this.currentLife -= _currentLife;

            if (this.currentLife <= 0)
                this.currentLife = 0;
        }

        public void removeEffects(_EffectsRemove _effects, int _value)
        {
            if (_effects == _EffectsRemove.Life)
            {
                this.currentLife -= _value;
            }
        }

        public void reverseEffects(_EffectsRemove _effects, int _value)
        {
            if (_effects == _EffectsRemove.Life)
            {
                this.currentLife += _value;
            }
        }
    }
}
