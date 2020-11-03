using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{ 
    public List<Card> GroupCards;
    public List<Card> HanderCards;
    public List<Card> CemeteryCards;
    public List<Card> DegeneratorCards;
    public List<MonsterCard> MonsterCards;
    public List<EffectCard> EffectCards;
    public EffectCard SceneCard;
    public void Start()
    {
        
    }
    public void InintCard()
    {
        GroupCards = new List<Card>();
        for (int i = 0; i < 20; i++)
        {
            GroupCards.Add(new MonsterCard(1));
        }
    }
    public void DrawCard()
    {
        Card card = GroupCards[0];
        GroupCards.Remove(card);
        HanderCards.Add(card);
    }
}
