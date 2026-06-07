using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Clicker clicker;
    
    [SerializeField] private List<Items> shopItems;
    
    [Header("Values")]
    [SerializeField] private float duration;


    private void Awake()
    {
    }

    private void Start()
    {
        shopItems[0].unlocked = true;
        foreach (Items item in shopItems)
        {
            item.index = 0;
        }
    }

    private void Update()
    {
        /*switch (indexIncrease)
        {
            case 0:
                increasePriceText.text = $"{increasePrice[indexIncrease]}$";
                break;
            case 1:
                increasePriceText.text = $"{increasePrice[indexIncrease]}$";
                break;
            case 2:
                increasePriceText.text = $"{increasePrice[indexIncrease]}$";
                break;
            case 3:
                btnIncreaseGain.GetComponent<Button>().enabled = false;
                increasePriceText.text = $"Maxed Out";
                break;
        }

        if (autoUnlocked)
        {
            switch (indexAutoIncrease)
            {
                case 0:
                    clicker.Score += Time.deltaTime  * 0.2f;
                    autoPriceText.text = $"{autoIncreasePrice[indexAutoIncrease]}$";
                    break;
                case 1:
                    clicker.Score += Time.deltaTime * 0.1f;
                    autoPriceText.text = $"{autoIncreasePrice[indexAutoIncrease]}$";
                    break;
                case 2:
                    clicker.Score += Time.deltaTime;
                    autoPriceText.text = $"{autoIncreasePrice[indexAutoIncrease]}$";
                    break;
                case 3:
                    clicker.Score += Time.deltaTime * 2f;
                    btnAutoGain.GetComponent<Button>().enabled = false;
                    autoPriceText.text = $"Maxed Out";
                    break;
            }
        }*/
    }

    public void SunnyCaramel()
    {
        if (clicker.Score >= shopItems[0].prices[shopItems[0].index])
        {
            switch (shopItems[0].index)
            {
                case 0:
                    clicker.gain += 2;
                    clicker.Score -= shopItems[0].prices[shopItems[0].index];
                    shopItems[0].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 1:
                    clicker.gain += 5;
                    clicker.Score -= shopItems[0].prices[shopItems[0].index];
                    shopItems[0].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 2:
                    clicker.gain += 10;
                    clicker.Score -= shopItems[0].prices[shopItems[0].index];
                    shopItems[0].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 3:
                    clicker.gain += 20;
                    clicker.Score -= shopItems[0].prices[shopItems[0].index];
                    shopItems[0].maxed = true;
                    break;
                    
            }
        }
    }
    
    /*
    public void IncreaseGain()
    {
        if (clicker.Score >= increasePrice[indexIncrease])
        {
            switch (indexIncrease)
            {
                case 0:
                    clicker.gain += 2;
                    clicker.Score -= increasePrice[indexIncrease];
                    indexIncrease++;
                    break;
                case 1:
                    clicker.gain += 5;
                    clicker.Score -= increasePrice[indexIncrease];
                    indexIncrease++;
                    break;
                case 2:
                    clicker.gain += 10;
                    clicker.Score -= increasePrice[indexIncrease];
                    indexIncrease++;
                    break;
                case 3:
                    clicker.gain += 20;
                    clicker.Score -= increasePrice[indexIncrease];
                    break;
            }
        }
        else
        {
            StartCoroutine(InsufficientFundsRoutine(btnIncreaseGain.GetComponent<Image>()));
        }
    }

    public void AutoGain()
    {
        if (!autoUnlocked)
        {
            if (clicker.Score >= autoIncreasePrice[0])
            {
                clicker.Score -= autoIncreasePrice[0];
                autoUnlocked = true;
                indexAutoIncrease = 0;
            }
            else
            {
                StartCoroutine(InsufficientFundsRoutine(btnAutoGain.GetComponent<Image>()));
            }

            return;
        }
        
        if (clicker.Score >= autoIncreasePrice[indexAutoIncrease] && autoUnlocked)
        {
            switch (indexAutoIncrease)
            {
                case 0:
                    clicker.Score -= increasePrice[indexAutoIncrease];
                    indexAutoIncrease++;
                    break;
                case 1:
                    clicker.Score -= increasePrice[indexAutoIncrease];
                    indexAutoIncrease++;
                    break;
                case 2:
                    clicker.Score -= increasePrice[indexAutoIncrease];
                    indexAutoIncrease++;
                    break;
                case 3:
                    clicker.Score -= increasePrice[indexAutoIncrease];
                    break;
            }
        }
        else
        {
            StartCoroutine(InsufficientFundsRoutine(btnAutoGain.GetComponent<Image>()));
        }
    }*/

    private IEnumerator InsufficientFundsRoutine(Image buttoncolor)
    {
        Color startColor = Color.red;
        Color endColor = Color.white;

        float time = 0;
        while (time < duration)
        {
            time += Time.deltaTime;
            buttoncolor.color = Color.Lerp(startColor, endColor, time / duration);
            yield return null;
        }
        
        buttoncolor.color = endColor;
    }
    /*
     Upgrade 1: gain goes + 2
     Upgrade 2: Automatic gain. bool "hasUnlocked" becomes true on the first unlock and each upgrade after
     reduces delay
     more currencies?
     */
}
