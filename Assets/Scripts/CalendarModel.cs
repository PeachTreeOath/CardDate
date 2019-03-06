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
    public int currentDay = 1; // Tracks first day of week. Day 1 = Sunday, Day 2 = Monday...

    private Dictionary<int, ActivityCard> activityMap = new Dictionary<int, ActivityCard>(); // Map of week to activities that week

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncrementWeek()
    {
        currentWeek++;

        if (currentWeek % 4 == 0)
            currentMonth++;

        if (currentMonth % 4 == 0)
            currentYear++;

        // Check for gameover at year 4 end
    }
}
