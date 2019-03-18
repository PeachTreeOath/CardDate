using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPrototype : ScriptableObject
{
    public string id;
    public new string name;
    public string description;
    public RuntimeAnimatorController animation;
    public RarityType rarity;
    public int cost;
    public CardEffectType effect;

    [Header("Stat Gain Parameters")]
    public PlayerStatType statGainType;
    public int statGainAmount;

    [Header("Card Draw Parameters")]
    public int numCardsToDraw;

    public CardModel Instantiate()
    {
        return new CardModel(this);
    }
}
