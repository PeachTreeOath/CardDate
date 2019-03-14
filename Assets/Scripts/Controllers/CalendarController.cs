using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalendarController : SingletonBaseController<CalendarController, CalendarModel, CalendarView>
{

    void Start()
    {
        view.CreateInitialCalendar();
    }

    public void GotoNextWeek()
    {
        model.IncrementWeek();
        view.GotoNextWeek();
    }

    public void PlaceCard(CardModel cardModel, int year, int month, int day)
    {
        model.AddCard(cardModel, year, month, day);
    }

    public void RemoveCard(int year, int month, int day)
    {
        model.RemoveCard(year, month, day);
    }

    public void CalculateWeekResults()
    {

    }
}
