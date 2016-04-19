using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Lite
{
    interface IEffects
    {
        void removeEffects(_EffectsRemove _effect, int _value);
        void reverseEffects(_EffectsRemove _effects, int _value);
    }
}
