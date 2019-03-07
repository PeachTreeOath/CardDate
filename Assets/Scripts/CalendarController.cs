using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalendarController : Singleton<CalendarController>
{
    private CalendarModel model;
    private CalendarView view;

    protected override void Awake()
    {
        base.Awake();

        model = GetComponent<CalendarModel>();
        view = GetComponent<CalendarView>();
    }

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

    public void CalculateWeekResults()
    {

    }
}
