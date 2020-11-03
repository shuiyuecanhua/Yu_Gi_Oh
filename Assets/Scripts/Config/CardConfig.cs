using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
  
public static class CardConfigManager
{
    public static Dictionary<int,MonsterCardConfig.Config> MonsterConfig;
    public static void InintConfig()
    {
        string configpath = Application.dataPath + "/Config/MonsterCardConfig.json";
        List<MonsterCardConfig.Config> list;
        if (File.Exists(configpath))
        { 
            list = JsonUtility.FromJson<MonsterCardConfig>(File.ReadAllText(configpath)).List;
            foreach (var v in list)
            {
                MonsterConfig.Add(v.id,v);
            }
        }
        else
        {
            MonsterConfig = new Dictionary<int, MonsterCardConfig.Config>();
        }
    } 
    
}
[Serializable]
public class MonsterCardConfig
{
    [SerializeField]
    public  List<Config> List = new List<Config>();
    [Serializable]
    public class Config
    {
        public int id = 1;
        public string name;
        public string desc;
        public int atk = 90;
        public int def = 90;
    }
}

