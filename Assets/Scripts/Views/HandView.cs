using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandView : BaseView<HandModel>
{

    [SerializeField] private Vector3 handCenter;
    [SerializeField] private float cardSpacing; // Factors both card width and space desired between cards

    public void SpawnCard(CardModel cardModel)
    {
        GameObject cardGO = Instantiate(ResourceLoader.instance.cardPrefab);
        cardGO.transform.SetParent(transform);
        cardGO.GetComponent<CardController>().InitCard(cardModel);
    }

    public void ArrangeCards()
    {
        CardView[] cards = GetComponentsInChildren<CardView>();

        // Initial spacing for the furthest card on the left
        float startXPos = handCenter.x - ((cards.Length / 2) * cardSpacing);

        // Cover case for even number of cards and spread out evenly
        if (cards.Length % 2 == 0)
            startXPos += cardSpacing / 2;

        for (int i = 0; i < cards.Length; i++)
        {
            float newXPos = startXPos + (i * cardSpacing);
            cards[i].transform.position = new Vector3(newXPos, handCenter.y, handCenter.z);
            cards[i].SetHomePosition();
        }
    }
}
