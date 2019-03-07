using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer cardBack;
    [SerializeField] private SpriteRenderer cardFace;

    private CardModel model;
    private CalendarWeekdaySlot overlappedSlot; // Slot the card is currently hovering over
    private bool isDragging;
    private Rigidbody2D rBody;

    void Awake()
    {
        model = GetComponent<CardModel>();
        rBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        ChangeColorToType();
    }

    private void ChangeColorToType()
    {
        Color newColor = Color.white;

        switch (model.type)
        {
            case CardType.CHARM:
                newColor = Color.magenta;
                break;
            case CardType.FASHION:
                newColor = Color.red;
                break;
            case CardType.MONEY:
                newColor = Color.yellow;
                break;
            case CardType.SPORTS:
                newColor = Color.green;
                break;
            case CardType.STUDY:
                newColor = Color.blue;
                break;
        }

        cardBack.color = newColor;
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
        overlappedSlot.AcceptCard(model);
        transform.position = overlappedSlot.transform.position;
        //TODO: fix positions
        // free up hand
    }
}
