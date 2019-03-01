using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLoader : Singleton<ResourceLoader>
{

    [HideInInspector] public GameObject scrollBGFab;

    protected override void Awake()
    {
        base.Awake();
        LoadResources();
    }

    private void LoadResources()
    {
        //scrollBGFab = Resources.Load<GameObject>("Prefabs/ScrollBG");
    }
}