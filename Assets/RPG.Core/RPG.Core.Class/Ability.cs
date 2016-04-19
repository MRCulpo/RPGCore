using System;
using System.Collections.Generic;


namespace RPG.Lite
{
    [System.Serializable]
    public class Ability
    {
        public int id;
        public string image;
        public string name;
	    public string desc;
        public float cooldown;
        public int cost;

	    public Damage damage;
	    public Armor armor;
        public Attributes attributes;
        public Effect[] effects;
        public _Element element;

	    public Ability()
	    {
            this.id = 0;
            this.image = "";
            this.name = "";
		    this.desc = "";
            this.cooldown = 0F;
            this.cost = 0;
		    this.damage = new Damage();
		    this.armor = new Armor();
            this.attributes = new Attributes();
            this.effects = new Effect[0];
            this.element = _Element.Null;
	    }
        public Ability ( Ability _ability)
	    {
            this.id = _ability.id;
            this.image = _ability.image;
            this.name = _ability.name;
            this.desc = _ability.desc;
            this.cooldown = _ability.cooldown;
            this.cost = _ability.cost;
            this.damage = _ability.damage;
            this.armor = _ability.armor;
            this.attributes = _ability.attributes;
            this.effects = _ability.effects;
            this.element = _ability.element;
	    }
        public void swapCooldown( float percentageCooldown )
        {
            this.cooldown = this.cooldown + (this.cooldown * percentageCooldown / 100);
        }
    }
}
