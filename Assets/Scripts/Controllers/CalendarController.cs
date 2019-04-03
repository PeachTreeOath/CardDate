using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalendarController : SingletonBaseController<CalendarController, CalendarModel, CalendarView>
{
    public int currentWeekCost;

    void Start()
    {
        view.CreateInitialCalendar();
        view.StartAcceptingWeekdayCards();
    }

    public bool GotoSaturday()
    {
        if (currentWeekCost <= PlayerStatsController.instance.model.statMap[PlayerStatType.STAMINA])
        {
            CalculateWeekdayResults();
            model.IncrementWeek();
            view.StopAcceptingWeekdayCards();
            view.StartAcceptingSaturdayInput();
            return true;
        }

        return false;
    }

    public void GotoSunday()
    {
        view.StopAcceptingSaturdayInput();
        view.StartAcceptingSundayInput();
    }

    public void GotoWeekday()
    {
        view.StopAcceptingSundayInput();
        model.IncrementWeek();
        view.GotoNextWeek(); // View will start accepting cards at the end of coroutine
    }

    public void PlaceCard(CardController card, int year, int month, int day)
    {
        model.AddCard(card, year, month, day);
        currentWeekCost += card.model.cost;
        PlayerStatsController.instance.RefreshView();
    }

    public void RemoveCard(int year, int month, int day)
    {
        CardController card = model.RemoveCard(year, month, day);
        currentWeekCost -= card.model.cost;
        PlayerStatsController.instance.RefreshView();
    }

    public void CalculateWeekdayResults()
    {
        int currentSunday = model.CalculateTotalDayForCurrentWeek();

        // Go through weekdays and perform all their actions
        for (int i = currentSunday + 1; i < currentSunday + 6; i++)
        {
            CardController card;
            model.activityMap.TryGetValue(i, out card);
            if (card)
            {
                card.PerformAction();
            }
        }

        // Apply stamina change then wipe current week's card cost
        PlayerStatsController.instance.AdjustStatBy(PlayerStatType.STAMINA, -currentWeekCost);
        currentWeekCost = 0;
        PlayerStatsController.instance.RefreshView();
    }
}
