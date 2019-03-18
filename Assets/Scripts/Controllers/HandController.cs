using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HandController : SingletonBaseController<HandController, HandModel, HandView>
{
    // Saving the card controllers here in addition to the models so that we can have more freedom to manipulate cards
    public List<CardController> cards = new List<CardController>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            DrawFromDeck();
        }
    }

    public void DrawFromDeck()
    {
        CardModel newCardModel = DeckController.instance.DrawCard();
        CardController newCardController = view.SpawnCard(newCardModel);
        cards.Add(newCardController);
        view.UpdateCardViewsInHand(cards.Select(x => x.GetView()).ToList());
        view.ArrangeCards();
    }

    public void DiscardHand()
    {
        for (int i = cards.Count - 1; i >= 0; i--)
        {
            DiscardCard(cards[i]);
        }
    }

    public void DiscardCard(CardController card)
    {
        cards.Remove(card);
        DeckController.instance.AddToDiscardPile(card.model);
        view.DiscardCard(card);
        view.UpdateCardViewsInHand(cards.Select(x => x.GetView()).ToList());
    }
}
