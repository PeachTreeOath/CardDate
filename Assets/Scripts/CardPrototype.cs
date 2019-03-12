using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPrototype : ScriptableObject
{
    public string cardName;
    public CardType type;
    public int energyCost;
    public int numCardsToDraw;

    public Sprite sprite; // TODO: Change to gifs

    public CardModel Instantiate()
    {
        return new CardModel(this);
    }
}
