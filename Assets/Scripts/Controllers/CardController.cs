using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardController : BaseController<CardModel, CardView>
{
    private ICardAction cardAction;

    // Call this after setting the model to initialize the view
    public void InitCard(CardModel cardModel)
    {
        model = cardModel;
        SetCardAction(cardModel);
        view.InitCard(cardModel);
    }

    // TODO: Breaks the MVC paradigm but couldn't find a good way to get view to hand for manipulation
    public CardView GetView()
    {
        return view;
    }

    public void PerformAction()
    {
        cardAction.PerformAction();
    }

    private void SetCardAction(CardModel cardModel)
    {
        switch (cardModel.effect)
        {
            case CardEffectType.DRAW_CARDS:
                // TODO
                break;
            case CardEffectType.STAT_GAIN:
                cardAction = new StatGainCardAction();
                cardAction.Init(cardModel);
                break;
        }
    }
}
