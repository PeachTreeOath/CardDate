using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BaseView<M> : MonoBehaviour
    where M : BaseModel
{
    protected M model;

    public virtual void Setup(M model)
    {
        this.model = model;
    }
}
