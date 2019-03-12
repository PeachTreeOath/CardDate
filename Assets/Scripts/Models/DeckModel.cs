using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DeckModel : BaseModel
{
    public List<CardModel> library = new List<CardModel>();
    public List<CardModel> discard = new List<CardModel>();
    
}
