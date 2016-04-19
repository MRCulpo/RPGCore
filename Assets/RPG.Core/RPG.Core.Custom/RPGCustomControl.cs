using System;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Lite.RPGCustom
{
    [System.Serializable]
    public class RPGCustomControl 
    {

        public List<RPGCustomCharacter> characters;
        public Inventory bag;
        public RPGCustomCharacter characterControl;

        public RPGCustomControl()
        {
            this.characters = new List<RPGCustomCharacter>();
            this.characterControl = new RPGCustomCharacter();
            this.bag = new Inventory();
        }

        public void addExperience(float _exp) 
        {
            characterControl.addExperience(_exp);
        }

        public void addExperience(float[] _exp) 
        {
            for(int i = 0; i < characters.Count; i++)
            {
                characters[i].addExperience(_exp[i]);
            }
        }

        public void addExperience(float _exp, RPGCustomCharacter _character)
        {
            _character.addExperience(_exp);
        }

        public void addExperience(float[] _exp, List<RPGCustomCharacter> _characters)
        {
            for (int i = 0; i < _characters.Count; i++)
            {
                _characters[i].addExperience(_exp[i]);
            }
        }

        public bool chargeInventoryItems(int id_bag, int id_inventory)
        {
            Item _bag = this.bag.getItemIdObject(id_bag);
            
            Item _inventory = null;

            if (id_inventory >= 0)
            {
                _inventory = new Item();

                _inventory = characterControl.inventory.getItemIdObject(id_inventory);
            }

            if (characterControl.swapItemInventory(_bag, _inventory))
            {
                this.bag.item.Remove(this.bag.getItemIdObject(id_bag));

                if (id_inventory >= 0)
                {
                    this.bag.item.Add(_inventory);
                }

                return true;
            }
            return false;
        }
        public bool chargeInventoryItems(int id_bag, int id_inventory, RPGCustomCharacter _character)
        {
            Item _bag = this.bag.getItemIdObject(id_bag);

            Item _inventory = null;

            if (id_inventory >= 0)
            {
                _inventory = new Item();

                _inventory = _character.inventory.getItemIdObject(id_inventory);
            }

            if (_character.swapItemInventory(_bag, _inventory))
            {
                this.bag.item.Remove(this.bag.getItemIdObject(id_bag));

                if (id_inventory >= 0)
                {
                    this.bag.item.Add(_inventory);
                }

                return true;
            }
            return false;
        }
        public bool chargeAbility(Ability _current, Ability _last)
        {
            return characterControl.swapAbility(_current, _last);
        }
        public bool chargeAbility(Ability _current, Ability _last, RPGCustomCharacter _caracter)
        {
            return _caracter.swapAbility(_current, _last);
        }
    }
}
