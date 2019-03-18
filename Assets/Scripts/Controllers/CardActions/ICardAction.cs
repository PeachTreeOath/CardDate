using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICardAction
{
    void Init(CardModel cardModel);
    void PerformAction();
}
