using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : Singleton<InputManager>
{
    private CardView currentHoveredCard;
    private CalendarWeekdaySlot currentHoveredSlot;
    private CardView currentSelectedCard;
    private LineRenderer lineRenderer;
    [HideInInspector] public Transform handTransform;

    [SerializeField] private CanvasGroupToggler journalCanvas;
    private bool isShowingJournal;

    protected override void Awake()
    {
        base.Awake();

        lineRenderer = GetComponent<LineRenderer>();
        handTransform = GameObject.Find("Hand").transform;
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(1, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        CastRay();

        if (Input.GetMouseButtonDown(0))
        {
            HandleMouseClick(true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            HandleMouseClick(false);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            ResetSelection();
        }
    }

    public void ToggleJournal(bool toggleOn)
    {
        journalCanvas.ToggleGroup(toggleOn);
        isShowingJournal = toggleOn;
    }

    private void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        // Only do card logic on weekdays
        if (GameManager.instance.currentPhase == PlayPhase.WEEKDAY)
        {
            if (hit)
            {
                CardView cardHit = hit.collider.GetComponent<CardView>();
                CalendarWeekdaySlot slotHit = hit.collider.GetComponent<CalendarWeekdaySlot>();

                // Case when player moves mouse from board onto card or moves mouse off card onto another card
                if (currentHoveredCard != cardHit)
                {
                    if (currentHoveredCard)
                    {
                        currentHoveredCard.EndHover();
                    }
                }

                // Case when player hovers over a card
                if (cardHit)
                {
                    currentHoveredCard = cardHit;
                    currentHoveredCard.StartHover();
                    currentHoveredSlot = null;
                }

                // Case when player hovers over empty slot
                if (slotHit)
                {
                    currentHoveredSlot = slotHit;
                    currentHoveredCard = null;
                }
            }
            else
            {
                // No hits, reset all hovered

                // Case when player moves mouse off card onto board
                if (currentHoveredCard)
                {
                    currentHoveredCard.EndHover();
                    currentHoveredCard = null;
                }
                currentHoveredSlot = null;
            }
        }
    }

    private void HandleMouseClick(bool isMouseDown)
    {
        if (isMouseDown)
        {
            // Only do card logic on weekdays
            if (GameManager.instance.currentPhase == PlayPhase.WEEKDAY)
            {
                // Case when player clicks on a card
                if (currentHoveredCard)
                {
                    currentSelectedCard = currentHoveredCard;
                    if (currentSelectedCard.inHand)
                    {
                        // Clicked on card in hand, start selection
                        lineRenderer.enabled = true;
                        lineRenderer.SetPosition(0, currentSelectedCard.transform.position);
                    }
                    else
                    {
                        // Clicked on placed card, return to hand
                        currentSelectedCard.ReturnToHand();
                        ResetSelection();
                    }
                }
                // Case when player clicks on empty slot
                else if (currentHoveredSlot)
                {
                    // Make sure player has card selected before setting in slot, otherwise do nothing
                    if (currentSelectedCard)
                    {
                        currentSelectedCard.SetCardInSlot(currentHoveredSlot);
                        currentSelectedCard.EndHover();
                    }

                    ResetSelection();
                }
                // Case when player clicks in empty area
                else
                {
                    ResetSelection();
                }
            }
            else if (GameManager.instance.currentPhase == PlayPhase.SATURDAY)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

                if (hit)
                {
                    CalendarSaturdaySlot slotHit = hit.collider.GetComponent<CalendarSaturdaySlot>();
                    if (slotHit && slotHit.isActiveSlot && !isShowingJournal)
                        ToggleJournal(true);
                    else
                        ToggleJournal(false);
                }
                else
                {
                    ToggleJournal(false);
                }
            }
        }
    }

    private void ResetSelection()
    {
        currentSelectedCard = null;
        lineRenderer.enabled = false;
    }
}
