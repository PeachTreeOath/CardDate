using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer cardBack;
    [SerializeField] private SpriteRenderer cardFace;

    private Vector3 normalHandSize = new Vector3(0.6f, 0.6f, 1);
    private Vector3 hoveredHandSize = new Vector3(0.75f, 0.75f, 1);
    private Vector3 normalPlacedSize = new Vector3(0.35f, 0.35f, 1);
    private Vector3 hoveredPlacedSize = new Vector3(0.55f, 0.55f, 1);
    private Vector3 placedCardOffset = new Vector3(.3f, 0, 0);

    [HideInInspector] public bool inHand = true;
    [HideInInspector] public CardModel model;
    private Rigidbody2D rBody;
    private Vector3 originalHandPosition; // TODO: Switch this to dynamic hand
    //TODO change this to hover with mouse
    private CalendarWeekdaySlot overlappedSlot; // Slot the card is currently hovering over


    private bool isHovered;
    private bool isSelected;

    void Awake()
    {
        model = GetComponent<CardModel>();
        rBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        ChangeColorToType();
        originalHandPosition = transform.position;
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
        if (isSelected)
        {
            //Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //transform.position = new Vector2(point.x, point.y);
        }
    }

    public void StartHover()
    {
        if (isHovered) return;

        isHovered = true;
        if (inHand)
            transform.localScale = hoveredHandSize;
        else
            transform.localScale = hoveredPlacedSize;

        //TODO change sorting layer
    }

    public void EndHover()
    {
        if (!isHovered) return;

        isHovered = false;
        if (inHand)
            transform.localScale = normalHandSize;
        else
            transform.localScale = normalPlacedSize;

        //TODO change sorting layer
        //TODO check to see if card shrinks even when selected
    }

    /*
    public void StartSelection()
    {
        isSelected = true;
    }

    public void EndSelection()
    {
        isSelected = false;
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
    */

    public void SetCardInSlot(CalendarWeekdaySlot slot)
    {
        inHand = false;
        slot.AcceptCard(model);
        Vector3 newPosition = slot.transform.position + placedCardOffset;
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z); // Preserve z value
        transform.localScale = hoveredPlacedSize;
    }

    public void ReturnToHand()
    {
        inHand = true;
        transform.position = originalHandPosition;
        transform.localScale = normalHandSize;
    }
}
