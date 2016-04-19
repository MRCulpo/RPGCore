using UnityEngine;
using System.Collections;

public class JsonItemsBehaviour : MonoBehaviour 
{
    public static string loadAllSkills()
    {
        TextAsset _json = Resources.Load("Items/Skills") as TextAsset;
        return _json.text;
    }

    public static string loadAllWeapons()
    {
        TextAsset _json = Resources.Load("Items/Weapons") as TextAsset;
        return _json.text;
    }

    public static string loadAllCloths()
    {
        TextAsset _json = Resources.Load("Items/Cloths") as TextAsset;
        return _json.text;
    }
}
