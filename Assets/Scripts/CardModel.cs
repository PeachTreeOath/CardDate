using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardModel : MonoBehaviour
{
    public CardType type;

    public string GetCardName()
    {
        switch (type)
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
                return "Leisure Code";
            default:
                return "null";
        }
    }

    public string GetCardDescription()
    {
        switch(type)
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
