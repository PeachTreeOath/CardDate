using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCardCardAction : ICardAction
{
    private int cardAmount;

    public void Init(CardModel cardModel)
    {
        cardAmount = cardModel.numCardsToDraw;
    }

    public void PerformAction()
    {
        // TODO: Save off value so that more cards are drawn next turn
    }
}
