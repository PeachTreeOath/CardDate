using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandView : BaseView<HandModel>
{

    [SerializeField] private Vector3 handCenter;
    [SerializeField] private float cardSpacing; // Factors both card width and space desired between cards

    private List<CardView> cardViewsInHand = new List<CardView>();

    public CardController SpawnCard(CardModel cardModel)
    {
        CardController cardController = Instantiate(ResourceLoader.instance.cardPrefab).GetComponent<CardController>();
        cardController.transform.SetParent(transform);
        cardController.GetComponent<CardController>().InitCard(cardModel);
        // TODO: lerp this into the hand

        return cardController;
    }

    public void ArrangeCards()
    {
        // Initial spacing for the furthest card on the left
        float startXPos = handCenter.x - ((cardViewsInHand.Count / 2) * cardSpacing);

        // Cover case for even number of cards and spread out evenly
        if (cardViewsInHand.Count % 2 == 0)
            startXPos += cardSpacing / 2;

        for (int i = 0; i < cardViewsInHand.Count; i++)
        {
            float newXPos = startXPos + (i * cardSpacing);
            cardViewsInHand[i].transform.position = new Vector3(newXPos, handCenter.y, handCenter.z);
            cardViewsInHand[i].SetHomePosition();
        }
    }

    public void DiscardCard(CardController card)
    {
        // TODO: lerp this into the discard pile
        DestroyImmediate(card.gameObject);
    }

    // Call this with the controller in order to keep the view synced up. Otherwise
    // there may be instances where something is being Destroyed but the view won't
    // recognize it until the next frame
    public void UpdateCardViewsInHand(List<CardView> views)
    {
        cardViewsInHand = views;
    }
}
