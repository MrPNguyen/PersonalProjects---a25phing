using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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
    
    [SerializeField] private List<Animator> letterAnims;
    [SerializeField] private List<TextMeshProUGUI> letterInfoObjects;
    
    [Header("Texts to the letters")]
    [SerializeField, TextArea(5, 2)] private List<string> momLetterInfos;
    [SerializeField, TextArea(5, 2)] private List<string> dadLetterInfos;
    [SerializeField, TextArea(5, 2)] private List<string> sisterLetterInfos;
    [SerializeField, TextArea(5, 2)] private List<string> drHartLetterInfos;
    [SerializeField, TextArea(5, 2)] private List<string> mindLetterInfos;
    
    [Header("Ending")]
    [SerializeField] private GameObject ending;
    [SerializeField] private Animator endingAnim;
    private Animator shopAnim;
    [SerializeField] private ScreenShake screenShake;
    
    
    [Header("Values")]
    [SerializeField] private float duration;

    private float bubbletimer;
    private float timeBetweenClicks;

    private int upgradesBoughtCount;
    
    [Header("Cat")]
    [SerializeField] private GameObject cat;
    
    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource envelopeAudioSource;
    [SerializeField] private AudioClip purchaseSound;
    [SerializeField] private AudioClip insufficientFundsSound;
    [SerializeField] private AudioClip envelopeSound;
    [SerializeField] private AudioClip machineBreakingSound;
    [SerializeField] private AudioClip machineShuttingDownSound;
    [SerializeField] private GameObject backgroundMusic;
    
    private void Start()
    {
        shopAnim = GetComponent<Animator>();
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
                case 5:
                    timeBetweenClicks = Time.deltaTime * 8f;
                    clicker.Score += timeBetweenClicks;
                    
                    bubbletimer += timeBetweenClicks;

                    if (bubbletimer >= 1f)
                    {
                        clicker.SpawnSpeechBubbles();
                        bubbletimer = 0f;
                    }
                    break;
                case 6:
                    timeBetweenClicks = Time.deltaTime * 12f;
                    clicker.Score += timeBetweenClicks;
                    
                    bubbletimer += timeBetweenClicks;

                    if (bubbletimer >= 1f)
                    {
                        clicker.SpawnSpeechBubbles();
                        bubbletimer = 0f;
                    }
                    break;
                case 7:
                    timeBetweenClicks = Time.deltaTime * 15f;
                    clicker.Score += timeBetweenClicks;
                    
                    bubbletimer += timeBetweenClicks;

                    if (bubbletimer >= 1f)
                    {
                        clicker.SpawnSpeechBubbles();
                        bubbletimer = 0f;
                    }
                    break;
                case 8:
                    timeBetweenClicks = Time.deltaTime * 20f;
                    clicker.Score += timeBetweenClicks;
                    
                    bubbletimer += timeBetweenClicks;

                    if (bubbletimer >= 1f)
                    {
                        clicker.SpawnSpeechBubbles();
                        bubbletimer = 0f;
                    }
                    break;
                case 9:
                    timeBetweenClicks = Time.deltaTime * 36f;
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
                case 5:
                    timeBetweenClicks = Time.deltaTime * 80f;
                    clicker.Score += timeBetweenClicks;
                    
                    bubbletimer += timeBetweenClicks;

                    if (bubbletimer >= 1f)
                    {
                        clicker.SpawnSpeechBubbles();
                        bubbletimer = 0f;
                    }
                    break;
                case 6:
                    timeBetweenClicks = Time.deltaTime * 95f;
                    clicker.Score += timeBetweenClicks;
                    
                    bubbletimer += timeBetweenClicks;

                    if (bubbletimer >= 1f)
                    {
                        clicker.SpawnSpeechBubbles();
                        bubbletimer = 0f;
                    }
                    break;
                case 7:
                    timeBetweenClicks = Time.deltaTime * 120f;
                    clicker.Score += timeBetweenClicks;
                    
                    bubbletimer += timeBetweenClicks;

                    if (bubbletimer >= 1f)
                    {
                        clicker.SpawnSpeechBubbles();
                        bubbletimer = 0f;
                    }
                    break;
                case 8:
                    timeBetweenClicks = Time.deltaTime * 145f;
                    clicker.Score += timeBetweenClicks;
                    
                    bubbletimer += timeBetweenClicks;

                    if (bubbletimer >= 1f)
                    {
                        clicker.SpawnSpeechBubbles();
                        bubbletimer = 0f;
                    }
                    break;
                case 9:
                    timeBetweenClicks = Time.deltaTime * 180f;
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

        //Fixa timingen så att breven poppar upp på rätt tid.
        switch (upgradesBoughtCount)
        {
            case 1:
                break;
            case 2:
                letterInfoObjects[3].SetText(drHartLetterInfos[0]);
                letterAnims[3].SetTrigger("send");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                letterInfoObjects[1].SetText(dadLetterInfos[0]);
                letterAnims[1].SetTrigger("send");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 6:
                letterInfoObjects[2].SetText(sisterLetterInfos[0]);
                letterAnims[2].SetTrigger("send");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                letterInfoObjects[0].SetText(momLetterInfos[0]);
                letterAnims[0].SetTrigger("send");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 10:
                break;
            case 11:
                break;
            case 12:
                letterInfoObjects[2].SetText(sisterLetterInfos[1]);
                letterAnims[2].SetTrigger("send");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 13:
                break;
            case 14:
                break;
            case 15:
               
                break;
            case 16:
                break;
            case 17:
                letterInfoObjects[0].SetText(momLetterInfos[1]);
                letterAnims[0].SetTrigger("send");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 18:
                break;
            case 19:
                letterInfoObjects[4].SetText(mindLetterInfos[0]);
                letterAnims[4].SetTrigger("send");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 20:
                break;
            case 21:
                letterInfoObjects[3].SetText(drHartLetterInfos[1]);
                letterAnims[3].SetTrigger("send");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 22:
                break;
            case 23:
                break;
            case 24:
                break;
            case 25:
                letterInfoObjects[1].SetText(dadLetterInfos[1]);
                letterAnims[1].SetTrigger("send");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 26:
                break;
            case 27:
                break;
            case 28:
                letterInfoObjects[0].SetText(momLetterInfos[2]);
                letterAnims[0].SetTrigger("send");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 29:
                break;
            case 30:
                letterInfoObjects[4].SetText(mindLetterInfos[1]);
                letterAnims[4].SetTrigger("send");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 31:
                break;
            case 32:
                break;
            case 33:
                letterInfoObjects[1].SetText(dadLetterInfos[2]);
                letterAnims[1].SetTrigger("send");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 34:
                break;
            case 35:
                letterInfoObjects[4].SetText(mindLetterInfos[3]);
                letterAnims[4].SetTrigger("send");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 36:
                break;
            case 37:
                break;
            case 38:
                letterInfoObjects[4].SetText(mindLetterInfos[4]);
                letterAnims[4].SetTrigger("send");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 39:
                break;
            case 40:
                break;
            case 41:
                letterInfoObjects[3].SetText(drHartLetterInfos[3]);
                letterAnims[3].SetTrigger("send");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 42:
                break;
            case 43:
                break;
            case 44:
                break;
            case 45:
                letterInfoObjects[2].SetText(sisterLetterInfos[2]);
                letterAnims[2].SetTrigger("send");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 46:
                break;
            case 47:
                letterInfoObjects[4].SetText(mindLetterInfos[2]);
                letterAnims[4].SetTrigger("send");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 48:
                break;
            case 49:
                letterInfoObjects[3].SetText(sisterLetterInfos[2]);
                letterAnims[3].SetTrigger("send");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 50:
                break;
            case 51:
                break;
        }
    }

    //Lägg till upgradesBoughtCount++ på all uppgraderingar och fixa funktionaliteten av katt uppgraderingen.
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
                    shopItems[0].index++;
                    break;
                case 4:
                    clicker.gain += 80;
                    clicker.Score -= shopItems[0].prices[shopItems[0].index];
                    shopItems[0].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 5:
                    clicker.gain += 100;
                    clicker.Score -= shopItems[0].prices[shopItems[0].index];
                    shopItems[0].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 6:
                    clicker.gain += 140;
                    clicker.Score -= shopItems[0].prices[shopItems[0].index];
                    shopItems[0].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 7:
                    clicker.gain += 160;
                    clicker.Score -= shopItems[0].prices[shopItems[0].index];
                    shopItems[0].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 8:
                    clicker.gain += 180;
                    clicker.Score -= shopItems[0].prices[shopItems[0].index];
                    shopItems[0].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 9:
                    clicker.gain += 200;
                    clicker.Score -= shopItems[0].prices[shopItems[0].index];
                    shopItems[0].maxed = true;
                    TooltipUI.Instance.Refresh();
                    break;
                    
            }
            audioSource.PlayOneShot(purchaseSound);
        }
        else
        {
            StartCoroutine(InsufficientFundsRoutine(caramelButton.GetComponent<Image>()));
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
                    shopItems[2].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 4:
                    clicker.Score -= shopItems[2].prices[shopItems[2].index];
                    shopItems[2].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 5:
                    clicker.Score -= shopItems[2].prices[shopItems[2].index];
                    shopItems[2].index++;
                    shopItems[3].unlocked = true;
                    TooltipUI.Instance.Refresh();
                    break;
                case 6:
                    clicker.Score -= shopItems[2].prices[shopItems[2].index];
                    shopItems[2].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 7:
                    clicker.Score -= shopItems[2].prices[shopItems[2].index];
                    shopItems[2].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 8:
                    clicker.Score -= shopItems[2].prices[shopItems[2].index];
                    shopItems[2].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 9:
                    clicker.Score -= shopItems[2].prices[shopItems[2].index];
                    shopItems[2].index++;
                    shopItems[2].maxed = true;
                    TooltipUI.Instance.Refresh();
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
                    clicker.gain += 250;
                    clicker.Score -= shopItems[1].prices[shopItems[1].index];
                    shopItems[1].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 3:
                    clicker.gain += 500;
                    clicker.Score -= shopItems[1].prices[shopItems[1].index];
                    shopItems[1].index++;
                    break;
                case 4:
                    clicker.gain += 800;
                    clicker.Score -= shopItems[1].prices[shopItems[1].index];
                    shopItems[1].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 5:
                    clicker.gain += 1000;
                    clicker.Score -= shopItems[1].prices[shopItems[1].index];
                    shopItems[1].index++;
                    shopItems[2].unlocked = true;
                    TooltipUI.Instance.Refresh();
                    break;
                case 6:
                    clicker.gain += 1250;
                    clicker.Score -= shopItems[1].prices[shopItems[1].index];
                    shopItems[1].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 7:
                    clicker.gain += 1500;
                    clicker.Score -= shopItems[1].prices[shopItems[1].index];
                    shopItems[1].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 8:
                    clicker.gain += 2000;
                    clicker.Score -= shopItems[1].prices[shopItems[1].index];
                    shopItems[1].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 9:
                    clicker.gain += 3000;
                    clicker.Score -= shopItems[1].prices[shopItems[1].index];
                    shopItems[1].maxed = true;
                    TooltipUI.Instance.Refresh();
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
                    /**/
                    break;
                case 2:
                    clicker.Score -= shopItems[3].prices[shopItems[3].index];
                    shopItems[3].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 3:
                    clicker.Score -= shopItems[2].prices[shopItems[2].index];
                    shopItems[3].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 4:
                    clicker.Score -= shopItems[3].prices[shopItems[3].index];
                    shopItems[3].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 5:
                    clicker.Score -= shopItems[3].prices[shopItems[3].index];
                    shopItems[3].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 6:
                    clicker.Score -= shopItems[3].prices[shopItems[3].index];
                    shopItems[3].index++;
                    shopItems[4].unlocked = true;
                    TooltipUI.Instance.Refresh();
                    break;
                case 7:
                    clicker.Score -= shopItems[3].prices[shopItems[3].index];
                    shopItems[3].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 8:
                    clicker.Score -= shopItems[3].prices[shopItems[3].index];
                    shopItems[3].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 9:
                    clicker.Score -= shopItems[3].prices[shopItems[3].index];
                    shopItems[3].maxed = true;
                    TooltipUI.Instance.Refresh();
                    break;
            }
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
                    clicker.gain += 700;
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
                    clicker.gain += 1400;
                    clicker.Score -= shopItems[5].prices[shopItems[5].index];
                    shopItems[5].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 4:
                    clicker.gain += 2000;
                    clicker.Score -= shopItems[5].prices[shopItems[5].index];
                    shopItems[5].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 5:
                    clicker.gain += 2600;
                    clicker.Score -= shopItems[5].prices[shopItems[5].index];
                    shopItems[5].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 6:
                    clicker.gain += 3100;
                    clicker.Score -= shopItems[5].prices[shopItems[5].index];
                    shopItems[5].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 7:
                    clicker.gain += 4000;
                    clicker.Score -= shopItems[5].prices[shopItems[5].index];
                    shopItems[5].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 8:
                    clicker.gain += 4500;
                    clicker.Score -= shopItems[5].prices[shopItems[5].index];
                    shopItems[5].index++;
                    TooltipUI.Instance.Refresh();
                    break;
                case 9:
                    clicker.gain += 6000;
                    clicker.Score -= shopItems[5].prices[shopItems[5].index];
                    shopItems[5].maxed = true;
                    TooltipUI.Instance.Refresh();
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
            StartCoroutine(BadEnding());
        }
    }
    
    public void LightDoor()
    {
        if (clicker.Score >= specialShopItems[1].prices[specialShopItems[1].index])
        {
            clicker.Score = 0;
            clicker.gain = 0;
            StartCoroutine(GoodEnding());
        }
    }

    private IEnumerator InsufficientFundsRoutine(Image buttoncolor)
    {
        audioSource.PlayOneShot(insufficientFundsSound);
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
   
    private IEnumerator GoodEnding()
    {
        shopAnim.SetBool("open", false);
        shopAnim.SetBool("close", true);
        ending.gameObject.SetActive(true);
        StartCoroutine(screenShake.ScreenShakeRoutine());

        backgroundMusic.gameObject.SetActive(false);
        audioSource.PlayOneShot(machineBreakingSound);
        yield return new WaitForSeconds(machineBreakingSound.length + 3f);
        
        audioSource.PlayOneShot(machineShuttingDownSound);
        endingAnim.SetTrigger("good");

        yield return new WaitForSeconds(machineShuttingDownSound.length);

        SceneManager.LoadSceneAsync("GoodEnding", LoadSceneMode.Single);
    }
    
    private IEnumerator BadEnding()
    {
        shopAnim.SetBool("open", false);
        shopAnim.SetBool("close", true);
        ending.gameObject.SetActive(true);
        StartCoroutine(screenShake.ScreenShakeRoutine());
        
        backgroundMusic.gameObject.SetActive(false);
        audioSource.PlayOneShot(machineBreakingSound);
        yield return new WaitForSeconds(machineBreakingSound.length);

        audioSource.PlayOneShot(machineShuttingDownSound);
        endingAnim.SetTrigger("bad");

        yield return new WaitForSeconds(machineShuttingDownSound.length);

        SceneManager.LoadSceneAsync("BadEnding", LoadSceneMode.Single);
    }
}
