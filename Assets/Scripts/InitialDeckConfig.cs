using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(DeckController))]
public class InitialDeckConfig : MonoBehaviour {

    public List<CardPrototype> cardsToStart;

    void Start() {
        DeckModel deckModel = GetComponent<DeckModel>();
        if(cardsToStart == null) {
            cardsToStart = new List<CardPrototype>();
        }

        for(var i = cardsToStart.Count - 1; i >= 0; i--) {
            var card = cardsToStart[i];
            //deckModel.PutOnTop( card.Instantiate() );
        }
    }
}
