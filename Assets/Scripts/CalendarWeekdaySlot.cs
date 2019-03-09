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
        if (!isOccupied)
        {
            CalendarController.instance.PlaceCard(card, year, month, day);
            isOccupied = true;
        }
    }

    public void RemoveCard()
    {
        if (isOccupied)
        {
            // Remove card from map
            isOccupied = false;
        }
    }
}
