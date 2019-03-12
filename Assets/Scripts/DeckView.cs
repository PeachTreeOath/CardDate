using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeckView : MonoBehaviour
{
    [SerializeField] private TextMeshPro deckPileCount;
    [SerializeField] private TextMeshPro discardPileCount;

    private DeckModel model;

    void Awake()
    {
        model = GetComponent<DeckModel>();
    }

    public void UpdateDeckPileCount(int count)
    {
        deckPileCount.text = count.ToString();
    }

    public void UpdateDiscardPileCount(int count)
    {
        discardPileCount.text = count.ToString();
    }
}
