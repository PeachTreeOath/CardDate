using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalendarController : SingletonBaseController<CalendarController, CalendarModel, CalendarView>
{

    void Start()
    {
        view.CreateInitialCalendar();
        view.StartAcceptingWeekdayCards();
    }

    public void GotoNextWeek()
    {
        CalculateWeekResults();
        model.IncrementWeek();
        view.StopAcceptingWeekdayCards();
        view.GotoNextWeek(); // View will start accepting cards at the end of coroutine
    }

    public void PlaceCard(CardController cardController, int year, int month, int day)
    {
        model.AddCard(cardController, year, month, day);
    }

    public void RemoveCard(int year, int month, int day)
    {
        model.RemoveCard(year, month, day);
    }

    public void CalculateWeekResults()
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
    }
}
