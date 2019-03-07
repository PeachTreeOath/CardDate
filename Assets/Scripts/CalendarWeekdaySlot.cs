using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CalendarWeekdaySlot : ACalendarSlot
{
    public void AcceptCard(CardModel card)
    {
        CalendarController.instance.PlaceCard(card, year, month, day);
    }
}
