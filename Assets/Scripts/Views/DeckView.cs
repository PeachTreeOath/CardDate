using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeckView : BaseView<DeckModel>
{
    [SerializeField] private TextMeshPro deckPileCount;
    [SerializeField] private TextMeshPro discardPileCount;

    public void UpdateDeckPileCount(int count)
    {
        deckPileCount.text = count.ToString();
    }

    public void UpdateDiscardPileCount(int count)
    {
        discardPileCount.text = count.ToString();
    }
}
