using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalendarView : BaseView<CalendarModel>
{
    private Queue<GameObject> weekViewSlots = new Queue<GameObject>();
    private List<Vector3> weekViewSlotPositions = new List<Vector3>();
    private float weekViewSlotLerpSpeed = 1f;
    private float weekViewSlotYStartPos = 2.5f;
    private float weekViewSlotYDistance = -1.895f;
    private float dayViewSlotXStartPos = -7.26f;
    private float dayViewSlotXDistance = 2.42f;

    private void Start()
    {
        InitWeekViewSlotPositions();
    }

    // Initializes positions for the week slots. Intentionally does 5 instead of 3 so you can move new slots in and out.
    private void InitWeekViewSlotPositions()
    {
        for (int i = -1; i < 5; i++)
        {
            weekViewSlotPositions.Add(new Vector3(0, weekViewSlotYStartPos + (i * weekViewSlotYDistance), 0));
        }
    }

    public void GotoNextWeek()
    {
        // Create the 3rd week to appear on the calendar
        int incomingWeek = model.currentWeek + 2;
        GameObject weekGo = CreateCalendarWeek(incomingWeek);
        weekGo.transform.position = weekViewSlotPositions[4];
        weekViewSlots.Enqueue(weekGo);
        StartCoroutine("MoveViewSlotsCR");
    }

    public void CreateInitialCalendar()
    {
        int currentWeek = model.currentWeek;

        // Only show 3 weeks at a time
        for (int i = 0; i < 3; i++)
        {
            GameObject weekGo = CreateCalendarWeek(currentWeek);
            weekGo.transform.position = weekViewSlotPositions[i + 1];
            weekViewSlots.Enqueue(weekGo);
            currentWeek++;
        }
    }

    public void StopAcceptingWeekdayCards()
    {
        // Get current week
        GameObject go = weekViewSlots.Peek();

        CalendarWeekdaySlot[] daySlots = go.GetComponentsInChildren<CalendarWeekdaySlot>();
        foreach (CalendarWeekdaySlot daySlot in daySlots)
        {
            daySlot.StopAcceptingCards();
        }
    }

    public void StartAcceptingWeekdayCards()
    {
        // Get current week
        GameObject go = weekViewSlots.Peek();

        CalendarWeekdaySlot[] daySlots = go.GetComponentsInChildren<CalendarWeekdaySlot>();
        foreach (CalendarWeekdaySlot daySlot in daySlots)
        {
            daySlot.StartAcceptingCards();
        }
    }

    // Move calendar upwards to transition to next week
    private IEnumerator MoveViewSlotsCR()
    {
        float lerpValue = 0;

        while (lerpValue < 1)
        {
            lerpValue += weekViewSlotLerpSpeed * Time.deltaTime;

            int i = 0;
            foreach (GameObject go in weekViewSlots)
            {
                go.transform.position = Vector3.Lerp(weekViewSlotPositions[i + 1], weekViewSlotPositions[i], lerpValue);
                if (i == 0) // Fade out top week
                {
                    ACalendarSlot[] daySlots = go.GetComponentsInChildren<ACalendarSlot>();
                    foreach (ACalendarSlot daySlot in daySlots)
                    {
                        daySlot.SetAlpha(1 - lerpValue);
                    }
                }
                else if (i == 3) // Fade out bottom week
                {
                    ACalendarSlot[] daySlots = go.GetComponentsInChildren<ACalendarSlot>();
                    foreach (ACalendarSlot daySlot in daySlots)
                    {
                        daySlot.SetAlpha(lerpValue);
                    }
                }

                i++;
            }

            yield return null;
        }

        GameObject oldWeek = weekViewSlots.Dequeue();
        Destroy(oldWeek);

        StartAcceptingWeekdayCards();
    }

    private GameObject CreateCalendarWeek(int week)
    {
        int date = GetFirstDateOfWeek(week);
        GameObject weekGo = new GameObject();
        weekGo.name = "Week" + week;

        for (int i = 0; i < 7; i++)
        {
            GameObject dayGo;
            if (i == 0) // Sunday
                dayGo = CreateCalendarSunday(model.currentYear, model.currentMonth, model.currentWeek, date);
            else if (i == 6) // Saturday
                dayGo = CreateCalendarSaturday(model.currentYear, model.currentMonth, model.currentWeek, date);
            else // Weekday
                dayGo = CreateCalendarWeekday(model.currentYear, model.currentMonth, model.currentWeek, date);

            dayGo.name = model.currentMonth + "-" + date;
            dayGo.transform.SetParent(weekGo.transform);
            float slotXPos = dayViewSlotXStartPos + (i * dayViewSlotXDistance);
            dayGo.transform.localPosition = new Vector3(slotXPos, 0, 0);
            date++;
        }

        return weekGo;
    }

    private int GetFirstDateOfWeek(int week)
    {
        int weekOfMonth = (week - 1) % 4;
        return (weekOfMonth) * 7 + 1;
    }

    private GameObject CreateCalendarWeekday(int year, int month, int week, int day)
    {
        return ResourceLoader.instance.calendarWeekdaySlotPrefab;
    }

    private GameObject CreateCalendarSunday(int year, int month, int week, int day)
    {
        return ResourceLoader.instance.calendarSundaySlotPrefab;
    }

    private GameObject CreateCalendarSaturday(int year, int month, int week, int day)
    {
        return ResourceLoader.instance.calendarSaturdaySlotPrefab;
    }

    private GameObject CreateCalendarDay(GameObject prefab, int year, int month, int week, int day)
    {
        GameObject go = Instantiate(prefab);
        go.transform.SetParent(transform);
        ACalendarSlot slot = go.GetComponent<ACalendarSlot>();
        slot.InitDate(year, month, week, day);

        return go;
    }
}
