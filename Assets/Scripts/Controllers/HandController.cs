using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : SingletonBaseController<HandController, HandModel, HandView>
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            DrawFromDeck();
        }
    }

    public void DrawFromDeck()
    {
        CardModel newCard = DeckController.instance.Draw();
        model.cards.Add(newCard);

        view.SpawnCard(newCard);
        view.ArrangeCards();
    }
}
