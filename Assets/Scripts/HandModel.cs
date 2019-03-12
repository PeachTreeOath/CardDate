using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandModel : MonoBehaviour
{
    private List<CardModel> cards = new List<CardModel>();

    private void Awake()
    {
        view = GetComponent<HandView>();
    }

    public int GetCardCount()
    {
        return cards.Count;
    }

    public void AddToHand(CardModel card)
    {
        cards.Add(card);
    }
}
