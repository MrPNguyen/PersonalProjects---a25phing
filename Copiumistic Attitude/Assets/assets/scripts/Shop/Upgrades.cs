using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using URPGlitch;

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
    
    [Header("Ending")]
    [SerializeField] private GameObject ending;
    [SerializeField] private Animator endingAnim;
    private Animator shopAnim;
    [SerializeField] private ScreenShake screenShake;
    [SerializeField] private GameObject backgroundMusic;
    [SerializeField] private GameObject globalVolume;
    
    
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
    
    [Header("FX")]
    [SerializeField] private Volume globalVol;
    private Vignette vi;
    private ColorAdjustments ca;
    private AnalogGlitchVolume agv;
    
    [SerializeField] private AudioSource cheeryMusic;
    [SerializeField] private AudioSource sadMusic;
    [SerializeField] private AudioSource heartbeatSource;
    [SerializeField] private AudioClip heartbeatClip;
    private float heartbeatInterval = 1f;
    private readonly float minimumheartbeatInterval = 0.2f;
    private float heartbeatTimer;
    
    private void Start()
    {
        globalVol.profile.TryGet(out ca);
        globalVol.profile.TryGet(out vi);
        globalVol.profile.TryGet(out agv);
        cheeryMusic.volume = 1;
        sadMusic.volume = 0;
        heartbeatSource.volume = 0.20f;
        
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
        if (shopItems[1].unlocked)
        {
            switch (shopItems[1].index)
            {
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

        heartbeatTimer -= Time.deltaTime;
        if (heartbeatTimer <= 0f)
        {
            heartbeatSource.PlayOneShot(heartbeatClip);
            
            heartbeatTimer = heartbeatInterval;
        }
        
        //Fixa timingen så att breven poppar upp på rätt tid.
    }
    
    //Testa flytta alla gemensamma rader kod i varddera case till botten för mer komprimerad kod
    public void SunnyCaramel()
    {
        if (!shopItems[0].maxed && clicker.Score >= shopItems[0].prices[shopItems[0].index])
        {
            switch (shopItems[0].index)
            {
                case 0:
                    clicker.gain += 2;
                    break;
                case 1:
                    clicker.gain += 5;
                    break;
                case 2:
                    clicker.gain += 10;
                    shopItems[1].unlocked = true;
                    break;
                case 3:
                    clicker.gain += 20;
                    break;
                case 4:
                    clicker.gain += 80;
                    break;
                case 5:
                    clicker.gain += 100;
                    break;
                case 6:
                    clicker.gain += 140;
                    break;
                case 7:
                    clicker.gain += 160;
                    break;
                case 8:
                    clicker.gain += 180;
                    break;
                case 9:
                    clicker.gain += 200;
                    shopItems[0].maxed = true;
                    break;
                    
            }
            clicker.Score -= shopItems[0].prices[shopItems[0].index];
            shopItems[0].index++;
            upgradesBoughtCount++;
            
            UpdateUI();
            
            PlayLetter();
            TooltipUI.Instance.Refresh();
            audioSource.PlayOneShot(purchaseSound);
        }
        else
        {
            StartCoroutine(InsufficientFundsRoutine(caramelButton.GetComponent<Image>()));
        }
    }
    public void Happiness()
    {
        if (!shopItems[1].maxed && shopItems[1].unlocked && clicker.Score >= shopItems[1].prices[shopItems[1].index])
        {
            switch (shopItems[1].index)
            {
                case 5:
                    shopItems[2].unlocked = true;
                    break;
                case 9:
                    shopItems[1].maxed = true;
                    break;
            }
            clicker.Score -= shopItems[1].prices[shopItems[1].index];
            shopItems[1].index++;
            upgradesBoughtCount++;
            
            UpdateUI();

            PlayLetter();
            TooltipUI.Instance.Refresh();
            
            audioSource.PlayOneShot(purchaseSound);
        }
        else
        {
            StartCoroutine(InsufficientFundsRoutine(happinessButton.GetComponent<Image>()));
        }
    }
    public void Cat()
    {
        if (!shopItems[2].maxed && clicker.Score >= shopItems[2].prices[shopItems[2].index] && shopItems[2].unlocked)
        {
            clicker.Score -= shopItems[2].prices[shopItems[2].index];
            cat.gameObject.SetActive(true);
            shopItems[2].maxed = true;
            shopItems[3].unlocked = true;
            upgradesBoughtCount++;
            
            UpdateUI();
            
            PlayLetter();
            audioSource.PlayOneShot(purchaseSound);
            TooltipUI.Instance.Refresh();
        }
        else
        {
            StartCoroutine(InsufficientFundsRoutine(catButton.GetComponent<Image>()));
        }
    }
    public void Money()
    {
        if (!shopItems[3].maxed && shopItems[3].unlocked && clicker.Score >= shopItems[3].prices[shopItems[3].index])
        {
            switch (shopItems[3].index)
            {
                case 0:
                    clicker.gain += 50;
                    break;
                case 1:
                    clicker.gain += 100;
                    break;
                case 2:
                    clicker.gain += 250;
                    break;
                case 3:
                    clicker.gain += 500;
                    break;
                case 4:
                    clicker.gain += 800;
                    break;
                case 5:
                    clicker.gain += 1000;
                    shopItems[4].unlocked = true;
                    break;
                case 6:
                    clicker.gain += 1250;
                    break;
                case 7:
                    clicker.gain += 1500;
                    break;
                case 8:
                    clicker.gain += 2000;
                    break;
                case 9:
                    clicker.gain += 3000;
                    shopItems[3].maxed = true;
                    break;
            }
            clicker.Score -= shopItems[3].prices[shopItems[3].index];
            shopItems[3].index++;
            upgradesBoughtCount++;
            
            UpdateUI();
            
            PlayLetter();
            TooltipUI.Instance.Refresh();
            
            audioSource.PlayOneShot(purchaseSound);
        }
        else
        {
            StartCoroutine(InsufficientFundsRoutine(moneyButton.GetComponent<Image>()));
        }
    }
    
    public void Friends()
    {
        if (!shopItems[4].maxed && shopItems[4].unlocked && clicker.Score >= shopItems[4].prices[shopItems[4].index])
        {
            switch (shopItems[4].index)
            {
                case 6:
                    shopItems[5].unlocked = true;
                    break;
                case 9:
                    shopItems[4].maxed = true;
                    break;
            }
            clicker.Score -= shopItems[4].prices[shopItems[4].index];
            shopItems[4].index++;
            upgradesBoughtCount++;
            
            UpdateUI();
            
            PlayLetter();
            TooltipUI.Instance.Refresh();
            
            audioSource.PlayOneShot(purchaseSound);
        }
        else
        {
            StartCoroutine(InsufficientFundsRoutine(friendsButton.GetComponent<Image>()));
        }
    }
   
    public void Mint()
    {
        if (!shopItems[5].maxed && shopItems[5].unlocked && clicker.Score >= shopItems[5].prices[shopItems[5].index])
        {
            switch (shopItems[5].index)
            {
                case 0:
                    clicker.gain += 500;
                    break;
                case 1:
                    clicker.gain += 700;
                    break;
                case 2:
                    clicker.gain += 1000;
                    break;
                case 3:
                    clicker.gain += 1400;
                    break;
                case 4:
                    clicker.gain += 2000;
                    break;
                case 5:
                    clicker.gain += 2600;
                    break;
                case 6:
                    clicker.gain += 3100;
                    break;
                case 7:
                    clicker.gain += 4000;
                    break;
                case 8:
                    clicker.gain += 4500;
                    break;
                case 9:
                    clicker.gain += 6000;
                    shopItems[5].maxed = true;
                    break;
            }
            clicker.Score -= shopItems[5].prices[shopItems[5].index];
            shopItems[5].index++;
            upgradesBoughtCount++;
            
            UpdateUI();
            
            PlayLetter();
            TooltipUI.Instance.Refresh();
            
            audioSource.PlayOneShot(purchaseSound);
        }
        else
        {
            StartCoroutine(InsufficientFundsRoutine(mintButton.GetComponent<Image>()));
        }
    }

    public void DarkDoor()
    {
        if (clicker.Score >= specialShopItems[0].prices[specialShopItems[0].index] && specialShopItems[0].unlocked)
        {
            clicker.Score = 0;
            clicker.gain = 0;
            StartCoroutine(BadEnding());
        }
        else
        {
            StartCoroutine(InsufficientFundsRoutine(darkDoorButton.GetComponent<Image>()));
        }
    }
    
    public void LightDoor()
    {
        if (clicker.Score >= specialShopItems[1].prices[specialShopItems[1].index] && specialShopItems[1].unlocked)
        {
            clicker.Score = 0;
            clicker.gain = 0;
            StartCoroutine(GoodEnding());
        }
        else
        {
            StartCoroutine(InsufficientFundsRoutine(lightDoorButton.GetComponent<Image>()));
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
        globalVolume.gameObject.SetActive(false);
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
        globalVolume.gameObject.SetActive(false);
        audioSource.PlayOneShot(machineBreakingSound);
        yield return new WaitForSeconds(machineBreakingSound.length);

        audioSource.PlayOneShot(machineShuttingDownSound);
        endingAnim.SetTrigger("bad");

        yield return new WaitForSeconds(machineShuttingDownSound.length);

        SceneManager.LoadSceneAsync("BadEnding", LoadSceneMode.Single);
    }

    private void PlayLetter()
    {
        switch (upgradesBoughtCount)
        {
            case 1:
                break;
            case 2:
                letterAnims[3].SetTrigger("send1");
                break;
            case 3:
                letterAnims[5].SetTrigger("send1");
                break;
            case 4:
                break;
            case 5:
                letterAnims[1].SetTrigger("send1");
                break;
            case 6:
                letterAnims[2].SetTrigger("send1");
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                letterAnims[0].SetTrigger("send1");
                break;
            case 10:
                break;
            case 11:
                break;
            case 12:
                letterAnims[5].SetTrigger("send2");
                break;
            case 13:
                letterAnims[5].SetTrigger("send3");
                break;
            case 14:
                break;
            case 15:
                letterAnims[3].SetTrigger("send4");
                break;
            case 16:
                letterAnims[2].SetTrigger("send2");
                break;
            case 17:
                break;
            case 18:
                letterAnims[0].SetTrigger("send2");
                break;
            case 19:
                break;
            case 20:
                letterAnims[4].SetTrigger("send1");
                break;
            case 21:
                break;
            case 22:
                letterAnims[2].SetTrigger("send3");
                break;
            case 23:
                letterAnims[3].SetTrigger("send3");
                break;
            case 24:
                break;
            case 25:
                letterAnims[1].SetTrigger("send2");
                break;
            case 26:
                letterAnims[4].SetTrigger("send2");
                break;
            case 27:
                break;
            case 28:
                letterAnims[0].SetTrigger("send3");
                break;
            case 29:
                break;
            case 30:
                letterAnims[1].SetTrigger("send3");
                break;
            case 31:
                letterAnims[4].SetTrigger("send5");
                break;
            case 32:
                break;
            case 33:
                letterAnims[5].SetTrigger("send4");
                break;
            case 34:
                letterAnims[5].SetTrigger("send5");
                break;
            case 35:
                letterAnims[5].SetTrigger("send6");
                break;
            case 36:
                letterAnims[4].SetTrigger("send4");
                break;
            case 37:
                letterAnims[2].SetTrigger("send7");
                break;
            case 38:
                letterAnims[3].SetTrigger("send5");
                break;
            case 39:
                break;
            case 40:
                letterAnims[2].SetTrigger("send3");
                break;
            case 41:
                break;
            case 42:
                letterAnims[1].SetTrigger("send4");
                break;
            case 43:
                letterAnims[2].SetTrigger("send4");
                break;
            case 44:
                letterAnims[2].SetTrigger("send5");
                break;
            case 45:
                letterAnims[2].SetTrigger("send6");
                break;
            case 46:
                letterAnims[0].SetTrigger("send4");
                break;
            case 47:
                letterAnims[3].SetTrigger("send6");
                break;
            case 48:
                letterAnims[4].SetTrigger("send6");
                break;
            case 49:
                letterAnims[3].SetTrigger("send7");
                break;
            case 50:
                letterAnims[4].SetTrigger("send3");
                break;
            case 51:
                letterAnims[4].SetTrigger("send7");
                break;
        }
        envelopeAudioSource.PlayOneShot(envelopeSound);
    }

    private void UpdateUI()
    {
        ca.saturation.value -= 2;
        vi.intensity.value += 0.0006f;
        cheeryMusic.volume -= 0.02f;
        sadMusic.volume += 0.02f;
            
        agv.scanLineJitter.value += 0.002f;
        agv.verticalJump.value += 0.00004f;
        agv.horizontalShake.value += 0.00004f;
        agv.colorDrift.value += 0.00002f;
            
        heartbeatSource.volume += 0.02f;
        heartbeatInterval -= 0.015f;
        heartbeatInterval = Mathf.Max(heartbeatInterval, minimumheartbeatInterval);
    }
}
