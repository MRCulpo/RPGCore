using System;
using System.Collections.Generic;


namespace RPG.Lite
{
    [System.Serializable]
    public class Resistance
    {
        public int fire;
        public int frost;
        public int nature;
        public int dark;

        public Resistance()
        {
            this.fire = 0;
            this.frost = 0;
            this.nature = 0;
            this.dark = 0;
        }

        public Resistance( Resistance _resistence)
        {
            this.fire = _resistence.fire;
            this.frost = _resistence.frost;
            this.nature = _resistence.nature;
            this.dark = _resistence.dark;
        }

        public static Resistance operator + (Resistance _resi1, Resistance _resi2)
        {
            Resistance _resi = new Resistance();

            _resi.fire = _resi1.fire + _resi2.fire;
            _resi.frost = _resi1.frost + _resi2.frost;
            _resi.dark = _resi1.dark + _resi2.dark;
            _resi.nature = _resi1.nature + _resi2.nature;

            return _resi;
        }

        public static Resistance operator - (Resistance _resi1, Resistance _resi2)
        {
            Resistance _resi = new Resistance();

            _resi.fire = _resi1.fire - _resi2.fire;
            _resi.frost = _resi1.frost - _resi2.frost;
            _resi.dark = _resi1.dark - _resi2.dark;
            _resi.nature = _resi1.nature - _resi2.nature;

            if (_resi.fire <= 0) _resi.fire = 0;
            if (_resi.frost <= 0) _resi.frost = 0;
            if (_resi.dark <= 0) _resi.dark = 0;
            if (_resi.nature <= 0) _resi.nature = 0;

            return _resi;
        }

        public void addResistence( Resistance _resistence)
        {
            this.fire += _resistence.fire;
            this.frost += _resistence.frost;
            this.nature += _resistence.nature;
            this.dark += _resistence.dark;
        }

        public void removeResistence(Resistance _resistence)
        {
            this.fire -= _resistence.fire;
            this.frost -= _resistence.frost;
            this.nature -= _resistence.nature;
            this.dark -= _resistence.dark;

            if (this.fire <= 0) this.fire = 0;
            if (this.frost <= 0) this.frost = 0;
            if (this.nature <= 0) this.nature = 0;
            if (this.dark <= 0) this.dark = 0;
        }

        public override string ToString()
        {
            return string.Format("[Resistance: fire={0}, frost={1}, nature={2}, dark={3}]", fire, frost, nature, dark);
        }
    }
}
