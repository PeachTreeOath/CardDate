using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer cardBack;
    [SerializeField] private SpriteRenderer cardFace;
    [SerializeField] private Canvas canvas;
    [SerializeField] private SpriteRenderer image;

    private Vector3 normalHandSize = new Vector3(0.6f, 0.6f, 1);
    private Vector3 hoveredHandSize = new Vector3(0.75f, 0.75f, 1);
    private Vector3 normalPlacedSize = new Vector3(0.55f, 0.55f, 1);
    private Vector3 hoveredPlacedSize = new Vector3(0.75f, 0.75f, 1);
    private Vector3 hoveredOffset = new Vector3(0, 1, 0);
    private Vector3 placedOffset = new Vector3(.3f, 0, 0);

    [HideInInspector] public bool inHand = true;
    [HideInInspector] public CardModel model;
    private Rigidbody2D rBody;
    private Vector3 originalHandPosition; // TODO: Switch this to dynamic hand
    private Vector3 hoveredPosition;
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
        hoveredPosition = originalHandPosition + hoveredOffset;
    }

    private void ChangeColorToType()
    {
        Color newColor = Color.white;

        switch (model.type)
        {
            case CardType.CHARM:
                newColor = new Color(255f / 255f, 130f / 255f, 189f / 255f);
                break;
            case CardType.FASHION:
                newColor = new Color(190f / 255f, 70f / 255f, 230f / 255f);
                break;
            case CardType.MONEY:
                newColor = new Color(255f / 255f, 255f / 255f, 113f / 255f);
                break;
            case CardType.SPORTS:
                newColor = new Color(170f / 255f, 255f / 255f, 75f / 255f);
                break;
            case CardType.STUDY:
                newColor = new Color(103f / 255f, 199f / 255f, 254f / 255f);
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
        {
            transform.localScale = hoveredHandSize;
            transform.position = hoveredPosition;
        }
        else
        {
            transform.localScale = hoveredPlacedSize;
        }

        ChangeSortingLayer(true);
    }

    public void EndHover()
    {
        if (!isHovered) return;

        isHovered = false;
        if (inHand)
        {
            transform.localScale = normalHandSize;
            transform.position = originalHandPosition;
        }
        else
        {
            transform.localScale = normalPlacedSize;
        }

        ChangeSortingLayer(false);
    }

    private void ChangeSortingLayer(bool isHovered)
    {
        if (isHovered)
        {
            cardBack.sortingOrder = 10;
            cardFace.sortingOrder = 11;
            image.sortingOrder = 12;
            canvas.sortingOrder = 13;
        }
        else
        {
            cardBack.sortingOrder = 0;
            cardFace.sortingOrder = 1;
            image.sortingOrder = 2;
            canvas.sortingOrder = 3;
        }
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
        isHovered = true; // Done to make sure hover state is reset correctly after placement
        slot.AcceptCard(model);
        transform.SetParent(slot.transform);
        Vector3 newPosition = slot.transform.position + placedOffset;
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z); // Preserve z value
        transform.localScale = hoveredPlacedSize;
    }

    public void ReturnToHand()
    {
        inHand = true;
        transform.SetParent(InputManager.instance.handTransform);
        transform.position = originalHandPosition;
        transform.localScale = normalHandSize;
    }
}
