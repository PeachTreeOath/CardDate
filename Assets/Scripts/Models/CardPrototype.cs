using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPrototype : ScriptableObject
{
    public string cardName;
    public string cardDescription;
    public CardType type;
    public int energyCost;
    public int numCardsToDraw;
    public RuntimeAnimatorController animation;

    public CardModel Instantiate()
    {
        return new CardModel(this);
    }
}
