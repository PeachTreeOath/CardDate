using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeckView : BaseView<DeckModel>
{
    [SerializeField] private TextMeshPro deckPileCount;
    [SerializeField] private TextMeshPro discardPileCount;

    public void UpdateDeckPileCount()
    {
        deckPileCount.text = model.library.Count.ToString();
    }

    public void UpdateDiscardPileCount()
    {
        discardPileCount.text = model.discard.Count.ToString();
    }
}
