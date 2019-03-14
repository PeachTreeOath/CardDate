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

    // TODO: Temp
    public string GetCardName()
    {
        switch (model.type)
        {
            case CardType.MONEY:
                return "Work";
            case CardType.CHARM:
                return "Clubbing";
            case CardType.FASHION:
                return "Brush Hair";
            case CardType.SPORTS:
                return "Stretch Class";
            case CardType.STUDY:
                return "Code Course";
            default:
                return "null";
        }
    }

    public string GetCardDescription()
    {
        switch (model.type)
        {
            case CardType.MONEY:
                return "Gain 1 Money";
            case CardType.CHARM:
                return "Gain 1 Charm";
            case CardType.FASHION:
                return "Gain 1 Fashion";
            case CardType.SPORTS:
                return "Gain 1 Sports";
            case CardType.STUDY:
                return "Gain 1 Study";
            default:
                return "null";
        }
    }
}
