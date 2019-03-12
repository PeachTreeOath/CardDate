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
    public CardType type;
    public int energyCost;
    public int numCardsToDraw;

    public CardModel(CardPrototype prototype)
    {
        this.prototype = prototype;
        this.cardName = prototype.cardName;
        this.type = prototype.type;
        this.energyCost = prototype.energyCost;
        this.numCardsToDraw = prototype.numCardsToDraw;
    }
}