using System;
using System.Collections.Generic;

namespace RPG.Lite.RPGCustom
{
    [System.Serializable]
    public class RPGCustomCharacter 
    {
        public string name;
        public ExperienceLevel level;
        public Class typeClass;
        public Life life;
        public Damage damage;
        public Armor armor;
        public Attributes attributes;
        public Inventory inventory;
        public AbilityManager abilityManager;
        public List<Effect> effects;

        /// <summary>
        /// Contrutor sem parametro
        /// </summary>
        public RPGCustomCharacter()
        {
            this.name = "";
            this.typeClass = new Class();
            this.level = new ExperienceLevel();
            this.life = new Life();
            this.damage = new Damage();
            this.armor = new Armor();
            this.attributes = new Attributes();
            this.inventory = new Inventory();
            this.abilityManager = new AbilityManager();
            this.effects = new List<Effect>();
            this.level = new ExperienceLevel();
        }
        /// <summary>
        /// Método para atribuir experiencia
        /// </summary>
        /// <param name="_exp"></param>
        public void addExperience(float _exp)
        {
            level.addExperience(_exp, typeClass, attributes);
        }
        /// <summary>
        /// Método para fazer a troca de itens entre a mochila e o inventario (usual case)
        /// </summary>
        /// <param name="_bag"></param>
        /// <param name="_inventory"></param>
        /// <returns></returns>
        public bool swapItemInventory (Item _bag, Item _inventory)
        {
            if (_inventory == null)
            {
                if (_bag.typeItem == _Item.Weapons)
                {
                    this.addFeatures((Weapon)_bag);
                    this.inventory.addItemInventory(_bag);
                    return true;
                }
                else if (_bag.typeItem == _Item.Clothes)
                {
                    this.addFeatures((Clothes)_bag);
                    this.inventory.addItemInventory(_bag);
                    return true;
                }
            }
            else if (_bag.typeItem == _inventory.typeItem)
            {
                if (_bag.typeItem == _Item.Weapons)
                {
                    for (int i = 0; i < this.inventory.item.Count; i++)
                    {
                        if (inventory.item[i].id == _inventory.id)
                        {
                            this.removeFeatures((Weapon)_inventory);
                            this.addFeatures((Weapon)_bag);
                            this.inventory.item.Add(_bag);
                            this.inventory.item.RemoveAt(i);
                            return true;
                        }
                    }
                }
                else if (_bag.typeItem == _Item.Clothes)
                {
                    Clothes _auxBag = (Clothes)_bag;
                    
                    for (int i = 0; i < this.inventory.item.Count; i++)
                    {
                        if (inventory.item[i].typeItem == _Item.Clothes)
                        {
                            Clothes aux = (Clothes)this.inventory.item[i];

                            if (aux.typeCloths == _auxBag.typeCloths)
                            {
                                this.removeFeatures((Clothes)_inventory);
                                this.addFeatures((Clothes)_bag);
                                this.inventory.item.Add(_bag);
                                this.inventory.item.RemoveAt(i);
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Fazer a troca de habilidade da arvore de habilidade e as atuais usadas
        /// </summary>
        /// <param name="_current"></param>
        /// <param name="_last"></param>
        /// <returns></returns>
        public bool swapAbility (Ability _current, Ability _last)
        {
            return this.abilityManager.swapAbility(_current, _last);
        }

        /// <summary>
        /// Remover as caracteristicas das armas
        /// </summary>
        /// <param name="_weapon"></param>
        public void removeFeatures(Weapon _weapon)
        {
            this.damage -= _weapon.damage;
            this.attributes -= _weapon.attributes;
            /*
            this.damage.removeDamage(_weapon.damage);
            this.attributes.removeAttributes(_weapon.attributes);*/
        }
        /// <summary>
        /// Remover as caracteristicas dos vestimentos
        /// </summary>
        /// <param name="_cloths"></param>
        public void removeFeatures(Clothes _cloths)
        {
            this.armor -= _cloths.armor;
            this.attributes -= _cloths.attributes;
            /*
            this.armor.removeArmor(_cloths.armor);
            this.attributes.removeAttributes(_cloths.attributes);*/
        }
        /// <summary>
        /// Adicionar caracteristicas das armas
        /// </summary>
        /// <param name="_weapon"></param>
        public void addFeatures(Weapon _weapon)
        {
            this.damage += _weapon.damage;
            this.attributes += _weapon.attributes;
            /*
            this.damage.addDamage(_weapon.damage);
            this.attributes.addAttributes(_weapon.attributes);*/
        }
        /// <summary>
        /// Adicionar caracteristicas dos vestimentos
        /// </summary>
        /// <param name="_cloths"></param>
        public void addFeatures(Clothes _cloths)
        {
            this.armor += _cloths.armor;
            this.attributes += _cloths.attributes;
            /*
            this.armor.addArmor(_cloths.armor);
            this.attributes.addAttributes(_cloths.attributes);*/
        }
        /// <summary>
        /// Método do update dos efeitos, caso tenha algun efeitos o método vai rodar cada rotina de cada efeito
        /// </summary>
        public void updateEffects(float deltaTime)
        {
            
            for(int i = 0; i < effects.Count; i++)
            {
                effects[i].update(attributes, damage, armor, life, deltaTime);
            }

            this.removeEffect();
        }
        /// <summary>
        /// Método responsável por remover os efeitos
        /// </summary>
        void removeEffect()
        {
            if (effects.Count > 0)
            {
                for (int i = 0; i < effects.Count; i++)
                {
                    if (effects[i].get_c_cooldown() >= effects[i].cooldown)
                    {
                        effects.RemoveAt(i);
                    }
                }
            }
        }
    }
}
