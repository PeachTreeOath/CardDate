using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[Serializable]
public class CardModel : BaseModel
{
    public CardPrototype prototype;
    public string cardName;
    public string cardDescription;
    public CardType type;
    public int energyCost;
    public int numCardsToDraw;
    public RuntimeAnimatorController animation;

    public CardModel(CardPrototype prototype)
    {
        this.prototype = prototype;
        cardName = prototype.cardName;
        cardDescription = prototype.cardDescription;
        type = prototype.type;
        energyCost = prototype.energyCost;
        numCardsToDraw = prototype.numCardsToDraw;
        animation = prototype.animation;
    }
}