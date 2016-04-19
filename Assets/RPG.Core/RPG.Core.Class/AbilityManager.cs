using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace RPG.Lite
{
    [System.Serializable]
    public class AbilityManager
    {
        private List<Ability> abilitys;

        public AbilityManager()
        {
            this.abilitys = new List<Ability>();
        }

        public AbilityManager(List<Ability> _abilitys)
        {
            this.abilitys = _abilitys;
        }

        public Ability getAbility(int _id)
        {
            Ability _ability = new Ability();

            return _ability;
        }

        public bool swapAbility(Ability _current, Ability _last)
        {
            if (_last != null)
            {
                for (int i = 0; i < abilitys.Count; i++)
                {
                    if (abilitys[i].id == _last.id)
                    {
                        abilitys[i] = _current;
                        return true;
                    }
                }
            }
            else
            {
                abilitys.Add(_current);
                return true;
            }
            return false;
        }
    }
}
