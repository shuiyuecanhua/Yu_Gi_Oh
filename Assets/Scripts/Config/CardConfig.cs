using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[SerializeField]
public class CardConfigList
{
    public string configname= "CardConfig";
    public List<CardConfig> List;
    public CardConfigList()
    {
        List = new List<CardConfig>();
        configname = "CardConfig";
    }
}
public class CardConfig
{
    public string name="1";
    public int atk=90;
    public int def=80;
}
