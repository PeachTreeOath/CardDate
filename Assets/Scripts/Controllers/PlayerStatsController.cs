using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsController : SingletonBaseController<PlayerStatsController, PlayerStatsModel, PlayerStatsView>
{
    [SerializeField] private int startingStamina;
    [SerializeField] private int startingMoney;
    [SerializeField] private int startingHandSize;

    public void InitStats()
    {
        model.InitStatMap();
        model.statMap[PlayerStatType.STAMINA] = startingStamina;
        model.statMap[PlayerStatType.MONEY] = startingMoney;
        model.handSize = startingHandSize;
        view.UpdateStatsPanel();
    }

    public void AdjustStatBy(PlayerStatType stat, int change)
    {
        model.statMap[stat] += change;
        view.UpdateStatsPanel();
    }

    public int GetHandSize()
    {
        return model.handSize;
    }
}
