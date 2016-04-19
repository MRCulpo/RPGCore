using System;
using System.Collections.Generic;


namespace RPG.Lite
{
    /// <summary>
    /// 
    /// </summary>
    public enum _Class
    {
        Warrior, Wizard, Archer, Priest, None
    }
    /// <summary>
    /// 
    /// </summary>
    public enum _Cloths
    {
        Head, Chest, Ring, Neck, Legs, Hands, Null
    }
    /// <summary>
    /// 
    /// </summary>
    public enum _Item
    {
        Weapons, Clothes, Utilities, Null
    }
    /// <summary>
    /// 
    /// </summary>
    public enum _Weapon
    {
        Sword, Staff, Hands, Null
    }
    /// <summary>
    /// 
    /// </summary>
    public enum _Ability
    {
        Active, Passive, Null
    }
    /// <summary>
    /// 
    /// </summary>
    public enum _Element
    {
        Fire, Frost, Nature, Dark, Null
    }
    /// <summary>
    /// 
    /// </summary>
    public enum _Attributes
    {
        Strength, Agility, Intelligence, Stamina, None
    }
    /// <summary>
    /// 
    /// </summary>
    public enum _Condition
    {
        Stun, Poison, Slow, Burn, None
    }
    
    public enum _EffectsRemove
    {
        Life, Strength, Agility, Intelligence, Stamina, Armor, Parry, Fire,
        Frost, Dark, Nature, Damage, CriticalDamage, ElementalDamage, None
    }

}
