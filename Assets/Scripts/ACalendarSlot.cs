using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ACalendarSlot : MonoBehaviour
{
    public int year;
    public int month;
    public int week;
    public int day;

    public bool isOccupied;

    [SerializeField] protected TextMeshPro dateText;

    public void SetDayNumber(int day)
    {
        dateText.text = day.ToString();
    }

    public void InitDate(int year, int month, int week, int day)
    {
        this.year = year;
        this.month = month;
        this.week = week;
        this.day = day;
    }
}
