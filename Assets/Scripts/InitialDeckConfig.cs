using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(DeckController))]
public class InitialDeckConfig : MonoBehaviour
{

    public List<CardPrototype> startingCards;

    public void Init()
    {
        if (startingCards == null)
        {
            startingCards = new List<CardPrototype>();
        }

        for (var i = 0; i < startingCards.Count; i++)
        {
            CardPrototype card = startingCards[i];
            DeckController.instance.PutOnTop(card.Instantiate());
        }

        DeckController.instance.Shuffle();
    }
}
