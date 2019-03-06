using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalendarModel : MonoBehaviour
{

    public int currentYear = 1;
    public int currentMonth = 1;
    public int currentWeek = 1;
    public int currentDay = 1; // Day 1 = Sunday, Day 2 = Monday...
    private Dictionary<int, ActivityCard> activityMap = new Dictionary<int, ActivityCard>(); // Map of week to activities that week

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
