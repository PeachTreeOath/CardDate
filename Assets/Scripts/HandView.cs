using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandView : MonoBehaviour
{
    private HandModel model;

    void Awake()
    {
        model = GetComponent<HandModel>();
    }

}
