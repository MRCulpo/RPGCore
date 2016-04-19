using System;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Attribute
{
    public Dictionary<string, AttributeBase> dictionary;

    public Attribute()
    {
        this.dictionary = new Dictionary<string, AttributeBase>();
    }

    public Attribute(Dictionary<string, AttributeBase> _dictionary)
    {
        this.dictionary = new Dictionary<string, AttributeBase>();
    }

    public void setAttributes(string _name)
    {
        if (this.dictionary != null)
        {
            if (!this.dictionary.ContainsKey(_name))
                this.dictionary.Add(_name, new AttributeBase(_name));
        }
    }

    public void setAttributes(string _name, AttributeBase _base)
    {
        if (this.dictionary != null)
        {
            if(!this.dictionary.ContainsKey(_name))
                this.dictionary.Add(_name, _base);
        }
    }

    public AttributeBase getAttributes(string _name)
    {
        return dictionary[_name];
    }

    public override string ToString()
    {
        string _value = "";
        foreach (KeyValuePair<string, AttributeBase> _dictionary in this.dictionary)
        {
            AttributeBase _base = (AttributeBase)_dictionary.Value;
            _value += _base.ToString() + "\n";
        }

        return _value;
    }
}
[System.Serializable]
public class AttributeBase
{
    public string name;
    public float value;

    public AttributeBase(string _name , float _value)
    {
        this.name = _name;
        this.value = _value;
    }

    public AttributeBase(string _name)
    {
        this.name = _name;
        this.value = 0f;
    }

    public AttributeBase()
    {
        this.name = "";
        this.value = 0f;
    }

    public override string ToString()
    {
        string value = " Nome: " + this.name  + " ::: Valor: " + this.value.ToString();
        return value;
    }
}
