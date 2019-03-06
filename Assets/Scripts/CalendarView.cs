using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalendarView : MonoBehaviour
{
    private GameObject calendarSlotPrefab;
    private CalendarModel model;

    // Start is called before the first frame update
    void Start()
    {
        model = GetComponent<CalendarModel>();
    }

    private void CreateInitialCalendar()
    {
        int currentWeek = model.currentWeek;
        //limit game to 4 seasons per year, 4wks per year, 4 years
        for (int i = 0; i < 3; i++)
        {
            CreateCalendarWeek(currentWeek);
            currentWeek++;
        }
    }

    private void CreateCalendarWeek(int week)
    {
        int weekOfMonth = week % 4;
        int date = (weekOfMonth - 1) * 7 + 1;
        GameObject weekGo = new GameObject();
        weekGo.name = "Week" + weekOfMonth;

        for (int i = 0; i < 7; i++)
        {
            GameObject dayGo = CreateCalendarDay(model.currentYear, model.currentMonth, model.currentWeek, date);
            dayGo.name = model.currentMonth + "-" + date;
            dayGo.transform.SetParent(weekGo.transform);
            float slotXPos = -7.2f + (i * 2.4f);
            dayGo.transform.localPosition = new Vector3(slotXPos, 0, 0);
        }
    }

    private GameObject CreateCalendarDay(int year, int month, int week, int day)
    {
        GameObject go = Instantiate(calendarSlotPrefab);
        ACalendarSlot slot = go.GetComponent<ACalendarSlot>();
        slot.InitDate(year, month, week, day);

        return go;
    }
}
