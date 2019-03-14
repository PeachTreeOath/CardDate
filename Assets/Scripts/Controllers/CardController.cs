using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardController : BaseController<CardModel, CardView>
{

    // Call this after setting the model to initialize the view
    public void InitCard(CardModel cardModel)
    {
        model = cardModel;
        view.InitCard(cardModel);
    }

}
