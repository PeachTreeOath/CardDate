﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardView : BaseView<CardModel>
{
    [SerializeField] private SpriteRenderer cardBack;
    [SerializeField] private SpriteRenderer cardFace;
    [SerializeField] private SpriteRenderer costIcon;
    [SerializeField] private Canvas canvas;
    [SerializeField] private TextMeshProUGUI nameField;
    [SerializeField] private TextMeshProUGUI descriptionField;
    [SerializeField] private TextMeshProUGUI costField;
    [SerializeField] private SpriteRenderer image;
    [SerializeField] private Animator animator;

    private Vector3 normalHandSize = new Vector3(0.6f, 0.6f, 1);
    private Vector3 hoveredHandSize = new Vector3(0.75f, 0.75f, 1);
    private Vector3 normalPlacedSize = new Vector3(0.55f, 0.55f, 1);
    private Vector3 hoveredPlacedSize = new Vector3(0.75f, 0.75f, 1);
    private Vector3 hoveredOffset = new Vector3(0, 1, 0);
    private Vector3 placedOffset = new Vector3(.3f, 0, 0);

    private CalendarWeekdaySlot currentSlot;

    [HideInInspector] public bool inHand = true; // TODO: maybe move this to hand logic?
    private Rigidbody2D rBody;
    private Vector3 originalHandPosition; // TODO: Switch this to dynamic hand
    private Vector3 hoveredPosition;

    private bool isHovered;
    private bool isSelected;

    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    public void InitCard(CardModel cardModel)
    {
        model = cardModel;

        ChangeColorToType(model.statGainType);
        nameField.text = model.name;
        descriptionField.text = model.description;
        costField.text = model.cost.ToString();
        animator.runtimeAnimatorController = model.animation;
    }

    // Sets the proper card position in hand
    public void SetHomePosition()
    {
        originalHandPosition = transform.position;
        hoveredPosition = originalHandPosition + hoveredOffset;
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

    public void SetCardInSlot(CalendarWeekdaySlot slot)
    {
        if (slot.isOccupied)
            return;

        inHand = false;
        isHovered = true; // Done to make sure hover state is reset correctly after placement
        slot.AcceptCard(GetComponent<CardController>()); // TODO Fix this paradigm breaker
        currentSlot = slot;
        transform.SetParent(slot.transform);
        Vector3 newPosition = slot.transform.position + placedOffset;
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z); // Preserve z value
        transform.localScale = hoveredPlacedSize;
    }

    public void ReturnToHand()
    {
        currentSlot.RemoveCard();

        inHand = true;
        currentSlot = null;
        transform.SetParent(InputManager.instance.handTransform);
        transform.position = originalHandPosition;
        transform.localScale = normalHandSize;
        // TODO: Place back into hand controller and rearrange
    }

    private void ChangeColorToType(PlayerStatType cardType)
    {
        Color newColor = Color.white;

        switch (cardType)
        {
            case PlayerStatType.CHARM:
                newColor = new Color(255f / 255f, 130f / 255f, 189f / 255f);
                break;
            case PlayerStatType.FASHION:
                newColor = new Color(190f / 255f, 70f / 255f, 230f / 255f);
                break;
            case PlayerStatType.MONEY:
                newColor = new Color(255f / 255f, 255f / 255f, 113f / 255f);
                break;
            case PlayerStatType.SPORTS:
                newColor = new Color(170f / 255f, 255f / 255f, 75f / 255f);
                break;
            case PlayerStatType.STUDY:
                newColor = new Color(103f / 255f, 199f / 255f, 254f / 255f);
                break;
        }

        cardBack.color = newColor;
    }

    private void ChangeSortingLayer(bool isHovered)
    {
        if (isHovered)
        {
            cardBack.sortingOrder = 10;
            image.sortingOrder = 11;
            cardFace.sortingOrder = 12;
            costIcon.sortingOrder = 13;
            canvas.sortingOrder = 14;
        }
        else
        {
            cardBack.sortingOrder = 0;
            image.sortingOrder = 1;
            cardFace.sortingOrder = 2;
            costIcon.sortingOrder = 3;
            canvas.sortingOrder = 4;
        }
    }
}
