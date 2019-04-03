using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Currently the game is 4 years, 4 seasons/months per year, and 4 weeks per season.
/// </summary>
[Serializable]
public class CalendarModel : BaseModel
{

    public int currentYear = 1;
    public int currentMonth = 1;
    public int currentWeek = 1;

    public Dictionary<int, CardController> activityMap = new Dictionary<int, CardController>(); // Map of total day to activities

    public void IncrementWeek()
    {
        currentWeek++;

        if (currentWeek % 4 == 0)
        {
            currentWeek = 1;
            currentMonth++;
        }

        if (currentMonth % 4 == 0)
        {
            currentMonth = 1;
            currentYear++;
        }

        // TODO: Check for gameover at year 4 end
    }

    public void AddCard(CardController cardController, int year, int month, int day)
    {
        activityMap.Add(CalculateTotalDay(year, month, day), cardController);
    }

    public CardController RemoveCard(int year, int month, int day)
    {
        int date = CalculateTotalDay(year, month, day);
        CardController card = activityMap[date];
        activityMap.Remove(date);

        return card;
    }

    // Calculates actual day total of a certain week
    public int CalculateTotalDay(int year, int month, int day)
    {
        int totalDay = (year - 1) * 112;
        totalDay += (month - 1) * 28;
        totalDay += day;

        return totalDay;
    }

    // Calculates actual day total of the current week's sunday
    public int CalculateTotalDayForCurrentWeek()
    {
        int totalDay = (currentYear - 1) * 112;
        totalDay += (currentMonth - 1) * 28;
        totalDay += (currentWeek - 1) * 7;
        totalDay += 1;

        return totalDay;
    }
}
