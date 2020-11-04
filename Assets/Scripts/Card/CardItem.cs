using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    
}
public class MonsterCard: Card
{
    public MonsterCardConfig.Config cfg;
    public MonsterCard(int id)
    {
        cfg= CardConfigManager.MonsterConfig[id];
    }
}
public class EffectCard: Card
{

}
