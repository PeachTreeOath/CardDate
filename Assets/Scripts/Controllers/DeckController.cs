using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : SingletonBaseController<DeckController, DeckModel, DeckView>
{

    public void InitDeck()
    {
        GetComponent<InitialDeckConfig>().Init();
    }

    public void PutOnTop(CardModel card)
    {
        model.library.Add(card);
        view.UpdateDeckPileCount();
    }

    public CardModel DrawCard()
    {
        CardModel card = null;

        if (model.library.Count == 0)
        {
            Shuffle();
            //TODO notify the system there's been a shuffle!
        }

        if (model.library.Count > 0)
        {
            var index = model.library.Count - 1;
            card = model.library[index];
            model.library.RemoveAt(index);
        }

        view.UpdateDeckPileCount();

        return card;
    }

    public void Shuffle(bool addDiscard = true)
    {
        if (addDiscard)
        {
            model.library.AddRange(model.discard);
            if (model.discard.Count > 0)
            {
                view.UpdateDeckPileCount();

                /*
                //This will technically make the cards move to the deck at the same time a
                //Card comes into the hand when the deck is empty, but it moves so fast it looks fine
                Card card = transform.Find("Slot").GetComponent<ObjectSlot>().objectInSlot.GetComponent<Card>();
                transform.Find("Slot").GetComponent<ObjectSlot>().Release();
                card.MoveToDeck();
                transform.GetComponent<Deck>().Clear();
                */
            }
            model.discard.Clear();
            view.UpdateDiscardPileCount();
        }

        int count = model.library.Count;
        int last = count - 1;
        for (int i = 0; i < last; i++)
        {
            int randomIndex = Random.Range(i, count);
            CardModel temp = model.library[i];
            model.library[i] = model.library[randomIndex];
            model.library[randomIndex] = temp;
        }
    }

    public void AddToDiscardPile(CardModel card)
    {
        model.discard.Add(card);
        view.UpdateDiscardPileCount();
    }
}
