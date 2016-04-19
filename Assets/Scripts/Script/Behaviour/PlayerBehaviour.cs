using UnityEngine;
using System.Collections.Generic;
using LitJson;
using RPG.Lite;
using RPG.Lite.RPGCustom;

public class PlayerBehaviour : MonoBehaviour 
{
    public RPGCustomCharacter character;

	void Start()
	{

        this.character = new RPGCustomCharacter();
        this.character.inventory.init();
        this.character.level.baseExperienceLevel(1.1f, 110, 2);
        this.character.typeClass.typeClass = _Class.Warrior;
        this.character.typeClass.chargeClassModifier(3);
        this.character.addExperience(500000);

        this.createItems();
        
        //this.init();
        //this.bag = new Inventory();


        //this.inventory.addItemInventory(JsonMapper.ToObject<List<Weapon>>(JsonItemsBehaviour.loadAllWeapons()));
        //this.inventory.addItemInventory(JsonMapper.ToObject<List<Cloths>>(JsonItemsBehaviour.loadAllCloths()));

        /*
        foreach (Weapon w in _weapon)
        {
            inventory.addItemInventory(_weapon);
        }
        foreach (Cloths c in _cloths)
        {
            inventory.addItemInventory(_cloths);
        }*/


        //skillManager.skills = JsonMapper.ToObject<List<Skill>>(JsonItemsBehaviour.loadAllSkills());

        /*
        Cloths _c = new Cloths(new Item(), new Armor());

        Debug.Log(JsonMapper.ToJson(_c));

        Damage _damage = new Damage(10, 10, 0);
        Armor _armor = new Armor(100, 10, 0, 0, 0, 0);

        Skill _skill = new Skill(0, "Stand", "Blessing", "BLABAABLSSUHDUSHDS", 0 , _damage, _armor);

        Debug.Log(JsonMapper.ToJson(_skill));*/
	}
    void Update()
    {
        this.character.updateEffects(Time.deltaTime);
    }

    void createItems()
    {
        Clothes clothes = new Clothes();
        clothes.name = "BLACK HANW >>> Number:" + character.name;
        clothes.id = 5;
        clothes.typeItem = _Item.Clothes;
        clothes.typeCloths = _Cloths.Chest;
        clothes.armor.armor = Random.Range(1, 100);
        clothes.armor.parry = Random.Range(1, 100);
        character.inventory.addItemInventory(clothes);


        character.life.life = 5000;
        character.life.currentLife = character.life.life;

        for (int i = 0; i < 2; i++)
        {
            Effect.StatesEffect state = new Effect.StatesEffect();
            state.value = 45 * (i + 1);
            state.cooldownEffects = 3 * (i + 1);
            state.effectsRemove = _EffectsRemove.Life;
            state.instante =   i != 0 ? true : false;

            Effect effect = new Effect();

            effect.effects.Add(state);
            effect.cooldown = 40;

            character.effects.Add(effect);
        }
    }
}
