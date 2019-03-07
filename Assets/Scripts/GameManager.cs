using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastRay(true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            CastRay(false);
        }

        //TODO temp
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EndWeek();
        }
    }

    private void CastRay(bool isMouseDown)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit)
        {
            CardView handler = hit.collider.GetComponent<CardView>();
            if (handler)
            {
                if (isMouseDown)
                    handler.StartDrag();
                else
                    handler.EndDrag();
            }
        }
    }

    // Move calendar up 1 week
    private void EndWeek()
    {
        CalendarController.instance.GotoNextWeek();
    }
}
