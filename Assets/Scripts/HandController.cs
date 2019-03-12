using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    private HandModel model;

    void Awake()
    {
        model = GetComponent<HandModel>();
    }

    public void AddToHand(CardModel card)
    {
        model.AddToHand(card);
    }

    public int GeCardCount()
    {
        return model.GetCardCount();
    }
}
