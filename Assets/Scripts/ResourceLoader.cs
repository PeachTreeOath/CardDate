using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLoader : Singleton<ResourceLoader>
{
    [HideInInspector] public GameObject scrollBGPrefab;
    [HideInInspector] public GameObject calendarWeekdaySlotPrefab;
    [HideInInspector] public GameObject calendarSundaySlotPrefab;
    [HideInInspector] public GameObject calendarSaturdaySlotPrefab;
    [HideInInspector] public GameObject cardPrefab;

    protected override void Awake()
    {
        base.Awake();
        LoadResources();
    }

    private void LoadResources()
    {
        scrollBGPrefab = Resources.Load<GameObject>("Prefabs/ScrollBG");
        calendarWeekdaySlotPrefab = Resources.Load<GameObject>("Prefabs/CalendarWeekdaySlot");
        calendarSundaySlotPrefab = Resources.Load<GameObject>("Prefabs/CalendarSundaySlot");
        calendarSaturdaySlotPrefab = Resources.Load<GameObject>("Prefabs/CalendarSaturdaySlot");
        cardPrefab = Resources.Load<GameObject>("Prefabs/ActivityCard");
    }
}