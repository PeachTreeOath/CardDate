using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour
{
    public void PutOnTop(CardModel card)
    {
        library.Add(card);
    }

    public CardModel Draw()
    {
        CardModel card = null;

        if (library.Count == 0)
        {
            Shuffle();
            //TODO notify the system there's been a shuffle!
        }

        if (library.Count > 0)
        {
            var index = library.Count - 1;
            card = library[index];
            library.RemoveAt(index);
        }

        return card;
    }

    public void Shuffle(bool addDiscard = true)
    {
        if (addDiscard)
        {
            library.AddRange(discard);
            if (discard.Count > 0)
            {
                //This will technically make the cards move to the deck at the same time a
                //Card comes into the hand when the deck is empty, but it moves so fast it looks fine
                Card card = transform.Find("Slot").GetComponent<ObjectSlot>().objectInSlot.GetComponent<Card>();
                transform.Find("Slot").GetComponent<ObjectSlot>().Release();
                card.MoveToDeck();
                transform.GetComponent<Deck>().Clear();
            }
            discard.Clear();
        }

        int count = library.Count;
        int last = count - 1;
        for (int i = 0; i < last; i++)
        {
            int randomIndex = Random.Range(i, count);
            CardModel temp = library[i];
            library[i] = library[randomIndex];
            library[randomIndex] = temp;
        }
    }
}
