using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[Serializable]
public class CardModel : BaseModel
{
    public CardPrototype prototype;

    public string id;
    public string name;
    public string description;
    public RuntimeAnimatorController animation;
    public RarityType rarity;
    public int cost;
    public CardEffectType effect;

    // Stat Gain Parameters
    public PlayerStatType statGainType;
    public int statGainAmount;

    // Card Draw Parameters
    public int numCardsToDraw;

    public CardModel(CardPrototype prototype)
    {
        this.prototype = prototype;
        id = prototype.id;
        name = prototype.name;
        description = prototype.description;
        animation = prototype.animation;
        rarity = prototype.rarity;
        cost = prototype.cost;
        effect = prototype.effect;
        statGainType = prototype.statGainType;
        statGainAmount = prototype.statGainAmount;
        numCardsToDraw = prototype.numCardsToDraw;
    }
}