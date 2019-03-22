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

    [SerializeField] private TextMeshPro dateText;
    [SerializeField] private SpriteRenderer xMarkSprite;
    [SerializeField] private SpriteRenderer highlightBackground;
    [SerializeField] private float fadeSpeed;

    private bool isHighlighting;
    private Color initialHighlightColor;
    private SpriteRenderer[] sprites;
    private TextMeshPro[] texts;

    private void Awake()
    {
        sprites = GetComponentsInChildren<SpriteRenderer>();
        texts = GetComponentsInChildren<TextMeshPro>();
        initialHighlightColor = highlightBackground.color;
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

    public void MarkDate()
    {
        xMarkSprite.enabled = true;
    }

    public void HighlightSlot(bool toggleOn)
    {
        isHighlighting = toggleOn;
        highlightBackground.enabled = toggleOn;

        if (toggleOn)
        {
            StartCoroutine("HighlightSlotCR");
        }
    }

    private void SetDateText()
    {
        dateText.text = day.ToString();
    }

    private IEnumerator HighlightSlotCR()
    {
        float minimumAlpha = 0.2f;
        float alpha = minimumAlpha;
        bool isFadingIn = true;

        while (isHighlighting)
        {
            if (isFadingIn)
            {
                alpha += Time.deltaTime * fadeSpeed;
                if (alpha > 1) isFadingIn = !isFadingIn;
            }
            else
            {
                alpha -= Time.deltaTime * fadeSpeed;
                if (alpha < minimumAlpha) isFadingIn = !isFadingIn;
            }

            Color newColor = new Color(initialHighlightColor.r, initialHighlightColor.g, initialHighlightColor.b, alpha);
            highlightBackground.color = newColor;
            yield return null;
        }
    }
}
