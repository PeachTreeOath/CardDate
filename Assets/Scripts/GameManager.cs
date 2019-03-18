using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    private void Start()
    {
        StartGame(); // Separated in case we want to set up anything before starting
    }

    public void StartGame()
    {
        PlayerStatsController.instance.InitStats();
        DeckController.instance.InitDeck();
        DrawHand();
    }

    public void DrawHand()
    {
        for (int i = 0; i < PlayerStatsController.instance.GetHandSize(); i++)
        {
            HandController.instance.DrawFromDeck();
        }
    }

    // Move calendar up 1 week
    public void EndWeek()
    {
        CalendarController.instance.GotoNextWeek();
        HandController.instance.DiscardHand();
        DrawHand();
    }
}
