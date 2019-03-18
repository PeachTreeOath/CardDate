using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerStatsModel : BaseModel
{
    public Dictionary<PlayerStatType, int> statMap = new Dictionary<PlayerStatType, int>();

    public int handSize;

    public void InitStatMap()
    {
        foreach (PlayerStatType stat in Enum.GetValues(typeof(PlayerStatType)))
        {
            statMap.Add(stat, 0);
        }
    }
}
