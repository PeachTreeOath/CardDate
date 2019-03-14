using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLoader : Singleton<ResourceLoader>
{
    [HideInInspector] public GameObject scrollBGPrefab;
    [HideInInspector] public GameObject calendarDaySlotPrefab;
    [HideInInspector] public GameObject cardPrefab;

    public RuntimeAnimatorController moneyController;
    public RuntimeAnimatorController charmController;
    public RuntimeAnimatorController fashionController;
    public RuntimeAnimatorController sportsController;
    public RuntimeAnimatorController studyController;

    protected override void Awake()
    {
        base.Awake();
        LoadResources();
    }

    private void LoadResources()
    {
        scrollBGPrefab = Resources.Load<GameObject>("Prefabs/ScrollBG");
        calendarDaySlotPrefab = Resources.Load<GameObject>("Prefabs/CalendarDaySlot");
        cardPrefab = Resources.Load<GameObject>("Prefabs/ActivityCard");
    }
}