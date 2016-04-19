using UnityEngine;
using System.Collections;

public class TestDictionry : MonoBehaviour {
    
    public Attribute attribute;

	void Start () 
    {
        this.attribute = new Attribute();
        this.attribute.setAttributes("Strange");
        this.attribute.setAttributes("Intelligence");
        this.attribute.setAttributes("Agility");
        this.attribute.setAttributes("Armor");
        this.attribute.setAttributes("Fire");

        print(this.attribute.ToString());
	}
}
