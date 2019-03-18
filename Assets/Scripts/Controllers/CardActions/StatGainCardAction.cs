using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatGainCardAction : ICardAction
{
    private PlayerStatType gainType;
    private int gainAmount;

    public void Init(CardModel cardModel)
    {
        gainType = cardModel.statGainType;
        gainAmount = cardModel.statGainAmount;
    }

    public void PerformAction()
    {
        PlayerStatsController.instance.AdjustStatBy(gainType, gainAmount);
    }
}
