using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Currently the game is 4 years, 4 seasons/months per year, and 4 weeks per season.
/// </summary>
public class CalendarModel : MonoBehaviour
{

    public int currentYear = 1;
    public int currentMonth = 1;
    public int currentWeek = 1;

    private Dictionary<int, CardModel> activityMap = new Dictionary<int, CardModel>(); // Map of total day to activities

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

        // Check for gameover at year 4 end
    }

    public void AddCard(CardModel cardModel, int year, int month, int day)
    {
        activityMap.Add(CalculateTotalDay(year, month, day), cardModel);
    }

    private int CalculateTotalDay(int year, int month, int day)
    {
        int totalDay = (year - 1) * 112;
        totalDay += (month - 1) * 28;
        totalDay += day;

        return totalDay;
    }
}
