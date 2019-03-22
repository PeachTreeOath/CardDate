using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGroupToggler : MonoBehaviour
{
    private CanvasGroup group;

    // Start is called before the first frame update
    void Start()
    {
        group = GetComponent<CanvasGroup>();
    }

    public void ToggleGroup(bool toggleOn)
    {
        group.alpha = toggleOn ? 1 : 0;
        group.interactable = toggleOn;
        group.blocksRaycasts = toggleOn;
    }
}
