using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Lite
{
    [System.Serializable]
    public class Class
    {
        public _Class typeClass;
        public int classModifier;
        public Class()
        {
            this.typeClass = _Class.None;
            this.classModifier = 1;
        }
        public void chargeClassModifier(int _value)
        {
            if(_value >= 1)
                this.classModifier = _value;
        }
    }
}
