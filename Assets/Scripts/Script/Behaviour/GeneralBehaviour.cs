using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RPG.Lite;
using RPG.Lite.RPGCustom;


public class GeneralBehaviour : MonoBehaviour
{
    public List<GameObject> prefsNPC;
    public RPGCustomControl rpgCustomControl;

    [SerializeField]private int index;

    public void init()
    {
        this.index = 5;
        this.rpgCustomControl = new RPGCustomControl();
        this.rpgCustomControl.characters = new List<RPGCustomCharacter>();
        this.createItems();
        for (int i = 0; i < prefsNPC.Count; i++)
        {
            rpgCustomControl.characters.Add(prefsNPC[i].GetComponent<PlayerBehaviour>().character);
        }
    }

    public void chargeClothes()
    {
        rpgCustomControl.characterControl = rpgCustomControl.characters[index];

        int i = Random.Range(0, rpgCustomControl.bag.item.Count);
        int j = Random.Range(0, rpgCustomControl.characterControl.inventory.item.Count);

        Debug.Log(rpgCustomControl.characterControl.inventory.item.Count);

        Debug.Log(i + "  Na BAG:" + rpgCustomControl.bag.item[i].name);
        //Debug.Log(j + "  No Inventorio:" + rpgCustomControl.characterControl.inventory.item[j].name);

        Debug.Log( rpgCustomControl.chargeInventoryItems(rpgCustomControl.bag.item[i].id, rpgCustomControl.characterControl.inventory.item.Count > 0 ?  rpgCustomControl.characterControl.inventory.item[j].id : -1));

    }

    void createItems()
    {
        for (int i = 0; i < 3; i++)
        {

            Clothes clothes = new Clothes();
            clothes.id = i;
            clothes.name = "I AM : " + Random.Range(1, 5000).ToString();
            clothes.typeItem = _Item.Clothes;
            clothes.typeCloths = _Cloths.Chest;
            clothes.armor.armor = Random.Range(1, 100);
            clothes.armor.parry = Random.Range(1, 100);

            rpgCustomControl.bag.addItemInventory(clothes);
        }
    }

    public GameObject NPCChargeControl()
    {
        this.index++;
        if(this.index >= this.prefsNPC.Count)
        {
            this.index = 0;
        }
        return prefsNPC[this.index];
    }
}
