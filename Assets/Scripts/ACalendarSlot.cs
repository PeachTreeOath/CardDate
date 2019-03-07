using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public abstract class ACalendarSlot : MonoBehaviour
{
    public int year;
    public int month;
    public int week;
    public int day; // Date of slot 1-28

    public bool isOccupied;

    [SerializeField] protected TextMeshPro dateText;

    private SpriteRenderer[] sprites;
    private TextMeshPro[] texts;

    private void Awake()
    {
        sprites = GetComponentsInChildren<SpriteRenderer>();
        texts = GetComponentsInChildren<TextMeshPro>();
    }

    public void InitDate(int year, int month, int week, int day)
    {
        this.year = year;
        this.month = month;
        this.week = week;
        this.day = day;

        SetDateText();
    }

    public void SetAlpha(float alpha)
    {
        foreach (SpriteRenderer sprite in sprites)
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, alpha);

        foreach (TextMeshPro text in texts)
            text.alpha = alpha;
    }


    private void SetDateText()
    {
        dateText.text = day.ToString();
    }
}
