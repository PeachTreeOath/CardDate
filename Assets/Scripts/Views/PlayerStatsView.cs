using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatsView : BaseView<PlayerStatsModel>
{

    [SerializeField] private TextMeshProUGUI staminaText;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI charmText;
    [SerializeField] private TextMeshProUGUI fashionText;
    [SerializeField] private TextMeshProUGUI sportsText;
    [SerializeField] private TextMeshProUGUI studyText;
    [SerializeField] private CanvasGroupToggler statsTooltipPanel;
    [SerializeField] private TextMeshProUGUI statsTooltipText;

    private const string tooltipString = "test"; // TODO: Implement tooltip system

    private Color defaultColor;
    [SerializeField] private Color invalidColor;

    private void Start()
    {
        defaultColor = staminaText.color;
    }

    public void UpdateStatsPanel()
    {
        int newStamina = model.statMap[PlayerStatType.STAMINA] - CalendarController.instance.currentWeekCost;
        staminaText.text = newStamina.ToString();
        if (newStamina >= 0)
            staminaText.color = defaultColor;
        else
            staminaText.color = invalidColor;
        moneyText.text = model.statMap[PlayerStatType.MONEY].ToString();
        charmText.text = model.statMap[PlayerStatType.CHARM].ToString();
        fashionText.text = model.statMap[PlayerStatType.FASHION].ToString();
        sportsText.text = model.statMap[PlayerStatType.SPORTS].ToString();
        studyText.text = model.statMap[PlayerStatType.STUDY].ToString();

        statsTooltipText.text = tooltipString.ToString();
    }

    public void DisplayStatsGuide(bool toggleOn)
    {
        statsTooltipPanel.ToggleGroup(toggleOn);
    }
}
