using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalendarController : MonoBehaviour
{
    private CalendarModel model;
    private CalendarView view;

    private void Awake()
    {
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
}
