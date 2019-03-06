using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CalendarWeekdaySlot : ACalendarSlot
{
    private SpriteRenderer[] sprites;
    private TextMeshPro[] texts;

    private void Awake()
    {
        sprites = GetComponentsInChildren<SpriteRenderer>();
        texts = GetComponentsInChildren<TextMeshPro>();
    }

    public void SetAlpha(float alpha)
    {
        foreach (SpriteRenderer sprite in sprites)
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, alpha);

        foreach (TextMeshPro text in texts)
            text.alpha = alpha;
    }
}
