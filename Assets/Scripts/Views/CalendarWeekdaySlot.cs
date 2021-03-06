﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CalendarWeekdaySlot : ACalendarSlot
{
    public bool isOccupied = true; // Starts off true so that you can't place a card into any slot
    private CardController currentCard;

    public void AcceptCard(CardController card)
    {
        CalendarController.instance.PlaceCard(card, year, month, day);
        isOccupied = true;
        HighlightSlot(true);
    }

    public void RemoveCard()
    {
        CalendarController.instance.RemoveCard(year, month, day);
        isOccupied = false;
    }

    public void StartAcceptingCards()
    {
        isOccupied = false;
        HighlightSlot(true);
    }

    public void StopAcceptingCards()
    {
        isOccupied = true;
        HighlightSlot(false);
        MarkDate();
    }
}
