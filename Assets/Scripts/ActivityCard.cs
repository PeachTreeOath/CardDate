using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActivityCard : MonoBehaviour
{
    private CalendarWeekdaySlot overlappedSlot;
    private bool isDragging;
    private Rigidbody2D rBody;
    private SpriteRenderer spr;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (isDragging)
        {
            Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(point.x, point.y);
        }
    }

    public void StartDrag()
    {
        isDragging = true;
    }

    public void EndDrag()
    {
        isDragging = false;

        if (overlappedSlot)
        {
            SetCardInSlot();
        }
        else
        {
            // reset into hand
            //transform.position = square.faceLocation;
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        CalendarWeekdaySlot slot = col.GetComponent<CalendarWeekdaySlot>();
        if (slot)
        {
            overlappedSlot = slot;
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        CalendarWeekdaySlot slot = col.GetComponent<CalendarWeekdaySlot>();
        if (slot)
        {
            overlappedSlot = null;
        }
    }

    private void SetCardInSlot()
    {
      // free up hand
      // place into slot
    }
}
