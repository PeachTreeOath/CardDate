using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : SingletonBaseController<HandController, HandModel, HandView>
{

    public void AddToHand(CardModel card)
    {
        model.AddToHand(card);
    }

    public int GeCardCount()
    {
        return model.GetCardCount();
    }
}
