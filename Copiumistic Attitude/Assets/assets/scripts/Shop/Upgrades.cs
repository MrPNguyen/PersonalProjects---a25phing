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
    [SerializeField] private List<Items> specialShopItems;
    
    [SerializeField] private Image caramelButton;
    [SerializeField] private Image moneyButton;
    [SerializeField] private Image happinessButton;
    [SerializeField] private Image friendsButton;
    [SerializeField] private Image catButton;
    [SerializeField] private Image mintButton;
    [SerializeField] private Image darkDoorButton;
    [SerializeField] private Image lightDoorButton;
    
    [Header("Values")]
    [SerializeField] private float duration;

    private float bubbletimer;
    private float timeBetweenClicks;
    
    [Header("Cat")]
    [SerializeField] private GameObject cat;
    
    private void Start()
    {
        shopItems[0].unlocked = true;
        foreach (Items item in shopItems)
        {
            item.index = 0;
            item.maxed = false;
        }

        for (int i = 1; i < shopItems.Count; i++)
        {
            shopItems[i].unlocked = false;
        }

        foreach (Items specialItem in specialShopItems)
        {
            specialItem.index = 0;
            specialItem.unlocked = false;
        }
    }

    private void Update()
    {
        if (shopItems[2].unlocked)
        {
            switch (shopItems[2].index)
            {
                case 0:
                    timeBetweenClicks = Time.deltaTime * 1f;
                    clicker.Score += timeBetweenClicks;
                    
                    bubbletimer += timeBetweenClicks;

                    if (bubbletimer >= 1f)
                    {
                        clicker.SpawnSpeechBubbles();
                        bubbletimer = 0f;
                    }
                    break;
                case 1:
                    timeBetweenClicks = Time.deltaTime * 1.5f;
                    clicker.Score += timeBetweenClicks;
                    
                    bubbletimer += timeBetweenClicks;

                    if (bubbletimer >= 1f)
                    {
                        clicker.SpawnSpeechBubbles();
                        bubbletimer = 0f;
                    }
                    break;
                case 2:
                    timeBetweenClicks = Time.deltaTime * 2f;
                    clicker.Score += timeBetweenClicks;
                    
                    bubbletimer += timeBetweenClicks;

                    if (bubbletimer >= 1f)
                    {
                        clicker.SpawnSpeechBubbles();
                        bubbletimer = 0f;
                    }
                    break;
                case 3:
                    timeBetweenClicks = Time.deltaTime * 3f;
                    clicker.Score += timeBetweenClicks;
                    
                    bubbletimer += timeBetweenClicks;

                    if (bubbletimer >= 1f)
                    {
                        clicker.SpawnSpeechBubbles();
                        bubbletimer = 0f;
                    }
                    break;
                case 4:
                    timeBetweenClicks = Time.deltaTime * 6f;
                    clicker.Score += timeBetweenClicks;
                    
                    bubbletimer += timeBetweenClicks;

                    if (bubbletimer >= 1f)
                    {
                        clicker.SpawnSpeechBubbles();
                        bubbletimer = 0f;
                    }
                    break;
            }
        }
        
        if (shopItems[3].unlocked)
        {
            switch (shopItems[3].index)
            {
                case 0:
                    timeBetweenClicks = Time.deltaTime * 10f;
                    clicker.Score += timeBetweenClicks;
                    
                    bubbletimer += timeBetweenClicks;

                    if (bubbletimer >= 1f)
                    {
                        clicker.SpawnSpeechBubbles();
                        bubbletimer = 0f;
                    }
                    break;
                case 1:
                    timeBetweenClicks = Time.deltaTime * 15f;
                    clicker.Score += timeBetweenClicks;
                    
                    bubbletimer += timeBetweenClicks;

                    if (bubbletimer >= 1f)
                    {
                        clicker.SpawnSpeechBubbles();
                        bubbletimer = 0f;
                    }
                    break;
                case 2:
                    timeBetweenClicks = Time.deltaTime * 30f;
                    clicker.Score += timeBetweenClicks;
                    
                    bubbletimer += timeBetweenClicks;

                    if (bubbletimer >= 1f)
                    {
                        clicker.SpawnSpeechBubbles();
                        bubbletimer = 0f;
                    }
                    break;
                case 3:
                    timeBetweenClicks = Time.deltaTime * 40f;
                    clicker.Score += timeBetweenClicks;
                    
                    bubbletimer += timeBetweenClicks;

                    if (bubbletimer >= 1f)
                    {
                        clicker.SpawnSpeechBubbles();
                        bubbletimer = 0f;
                    }
                    break;
                case 4:
                    timeBetweenClicks = Time.deltaTime * 60f;
                    clicker.Score += timeBetweenClicks;
                    
                    bubbletimer += timeBetweenClicks;

                    if (bubbletimer >= 1f)
                    {
                        clicker.SpawnSpeechBubbles();
                        bubbletimer = 0f;
                    }
                    break;
            }
        }

        if (shopItems.TrueForAll(item => item.maxed))
        {
            foreach (var item in specialShopItems)
            {
                item.unlocked = true;
            }
        }
    }

    public void SunnyCaramel()
    {
        if (clicker.Score >= shopItems[0].prices[shopItems[0].index] && shopItems[0].maxed == false)
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
                    shopItems[1].unlocked = true;
                    TooltipUI.Instance.Refresh();
                    break;
                case 3:
                    clicker.gain += 20;
                    clicker.Score -= shopItems[0].prices[shopItems[0].index];
                    shopItems[0].maxed = true;
                    break;
                    
            }
        }
        else
        {
            StartCoroutine(InsufficientFundsRoutine(caramelButton.GetComponent<Image>()));
        }
    }
    public void Money()
    {
        if (clicker.Score >= shopItems[1].prices[shopItems[1].index] && shopItems[1].maxed == false)
        {
            switch (shopItems[1].index)
            {
                case 0:
                    clicker.gain += 50;
                    clicker.Score -= shopItems[1].prices[shopItems[1].index];
                    shopItems[1].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 1:
                    clicker.gain += 100;
                    clicker.Score -= shopItems[1].prices[shopItems[1].index];
                    shopItems[1].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 2:
                    clicker.gain += 500;
                    clicker.Score -= shopItems[1].prices[shopItems[1].index];
                    shopItems[1].index++;
                    shopItems[2].unlocked = true;
                    TooltipUI.Instance.Refresh();
                    break;
                case 3:
                    clicker.gain += 1000;
                    clicker.Score -= shopItems[1].prices[shopItems[1].index];
                    shopItems[1].maxed = true;
                    break;
                    
            }
        }
    }
    public void Happiness()
    {
        if (clicker.Score >= shopItems[2].prices[shopItems[2].index] && shopItems[2].maxed == false)
        {
            switch (shopItems[2].index)
            {
                case 0:
                    clicker.Score -= shopItems[2].prices[shopItems[2].index];
                    shopItems[2].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 1:
                    clicker.Score -= shopItems[2].prices[shopItems[2].index];
                    shopItems[2].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 2:
                    clicker.Score -= shopItems[2].prices[shopItems[2].index];
                    shopItems[2].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 3:
                    clicker.Score -= shopItems[2].prices[shopItems[2].index];
                    shopItems[3].unlocked = true;
                    shopItems[2].maxed = true;
                    break;
                    
            }
        }
    }
    public void Friends()
    {
        if (clicker.Score >= shopItems[3].prices[shopItems[3].index] && shopItems[3].maxed == false)
        {
            switch (shopItems[3].index)
            {
                case 0:
                    clicker.Score -= shopItems[3].prices[shopItems[3].index];
                    shopItems[3].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 1:
                    clicker.Score -= shopItems[3].prices[shopItems[3].index];
                    shopItems[3].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 2:
                    clicker.Score -= shopItems[3].prices[shopItems[3].index];
                    shopItems[3].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 3:
                    clicker.Score -= shopItems[2].prices[shopItems[2].index];
                    shopItems[4].unlocked = true;
                    shopItems[3].maxed = true;
                    break;
                    
            }
        }
    }
    public void Cat()
    {
        if (clicker.Score >= shopItems[4].prices[shopItems[4].index] && shopItems[4].maxed == false)
        {
            clicker.Score -= shopItems[4].prices[shopItems[4].index];
            cat.gameObject.SetActive(true);
            TooltipUI.Instance.Refresh();
            shopItems[5].unlocked = true;
            shopItems[4].maxed = true;
        }
    }
    public void Mint()
    {
        if (clicker.Score >= shopItems[5].prices[shopItems[5].index] && shopItems[5].maxed == false)
        {
            switch (shopItems[5].index)
            {
                case 0:
                    clicker.gain += 500;
                    clicker.Score -= shopItems[5].prices[shopItems[5].index];
                    shopItems[5].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 1:
                    clicker.gain += 800;
                    clicker.Score -= shopItems[5].prices[shopItems[5].index];
                    shopItems[5].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 2:
                    clicker.gain += 1000;
                    clicker.Score -= shopItems[5].prices[shopItems[5].index];
                    shopItems[5].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 3:
                    clicker.gain += 2000;
                    clicker.Score -= shopItems[5].prices[shopItems[5].index];
                    shopItems[5].maxed = true;
                    break;
            }
        }
    }

    public void DarkDoor()
    {
        if (clicker.Score >= specialShopItems[0].prices[specialShopItems[0].index])
        {
            clicker.Score = 0;
            clicker.gain = 0;
            //Add transition to prologue bad ending
            //Broken machine sound effect
        }
    }
    
    public void LightDoor()
    {
        if (clicker.Score >= specialShopItems[1].prices[specialShopItems[1].index])
        {
            clicker.Score = 0;
            clicker.gain = 0;
            //Add transition to prologue good ending
            //Broken machine sound effect
        }
    }

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
