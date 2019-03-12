using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BaseController<M,V> : MonoBehaviour
    where M : BaseModel
    where V : BaseView<M>, new()
{
    public M model;
    protected V view;

    public virtual void Awake()
    {
        view = GetComponent<V>();
        view.Setup(model);
    }
}
