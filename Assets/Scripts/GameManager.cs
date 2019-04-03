using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{

    public PlayPhase currentPhase;

    private void Start()
    {
        StartGame(); // Separated in case we want to set up anything before starting
    }

    public void StartGame()
    {
        currentPhase = PlayPhase.WEEKDAY;
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
    public void EndPhase()
    {
        switch (currentPhase)
        {
            case PlayPhase.WEEKDAY:
                bool gotoSaturday = CalendarController.instance.GotoSaturday();
                if (gotoSaturday)
                    currentPhase = PlayPhase.SATURDAY;
                break;
            case PlayPhase.SATURDAY:
                HandController.instance.DiscardHand();
                CalendarController.instance.GotoSunday();
                currentPhase = PlayPhase.SUNDAY;
                break;
            case PlayPhase.SUNDAY:
                CalendarController.instance.GotoWeekday();
                DrawHand();
                currentPhase = PlayPhase.WEEKDAY;
                break;
        }
    }

    public void GotoPhase(PlayPhase phase)
    {
        currentPhase = phase;
    }
}
