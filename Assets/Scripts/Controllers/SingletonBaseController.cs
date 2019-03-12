using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SingletonBaseController<T, M, V> : BaseController<M, V>
    where T : SingletonBaseController<T, M, V>
    where M : BaseModel
    where V : BaseView<M>, new()
{
    public static T instance;

    public override void Awake()
    {
        base.Awake();

        if (instance == null)
        {
            instance = (T)this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
