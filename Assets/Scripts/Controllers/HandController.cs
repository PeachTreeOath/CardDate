using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : SingletonBaseController<HandController, HandModel, HandView>
{

    public void AddToHand(CardModel card)
    {
        model.cards.Add(card);
    }

    public int GeCardCount()
    {
        return model.cards.Count;
    }
}
