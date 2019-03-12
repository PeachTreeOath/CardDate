using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HandModel : BaseModel
{
    private List<CardModel> cards = new List<CardModel>();
  
    public int GetCardCount()
    {
        return cards.Count;
    }

    public void AddToHand(CardModel card)
    {
        cards.Add(card);
    }
}
