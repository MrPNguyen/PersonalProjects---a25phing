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
    private bool autoGainUnlocked;

    private double bubbletimer;

    private int upgradesBoughtCount;

    [HideInInspector] public bool isLetterActive;
    
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
        autoGainUnlocked = false;
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
        if (autoGainUnlocked)
        {
            if (shopItems[1].unlocked)
            {
                switch (shopItems[1].index)
                {
                    case 1: clicker.autoGain = Time.deltaTime * 1000f; break;
                    case 2: clicker.autoGain = Time.deltaTime * 3000f; break;
                    case 3: clicker.autoGain = Time.deltaTime * 5500f; break;
                    case 4: clicker.autoGain = Time.deltaTime * 6200f; break;
                    case 5: clicker.autoGain = Time.deltaTime * 7700f; break;
                    case 6: clicker.autoGain = Time.deltaTime * 8500f; break;
                    case 7: clicker.autoGain = Time.deltaTime * 9000f; break;
                    case 8: clicker.autoGain = Time.deltaTime * 13500f; break;
                    case 9: clicker.autoGain = Time.deltaTime * 18500f; break;
                }
            }
            if (shopItems[3].unlocked)
            {
                switch (shopItems[3].index)
                {
                    case 1: clicker.autoGain = Time.deltaTime * 20000f; break;
                    case 2: clicker.autoGain = Time.deltaTime * 32000f; break;
                    case 3: clicker.autoGain = Time.deltaTime * 51000f; break;
                    case 4: clicker.autoGain = Time.deltaTime * 69000f; break;
                    case 5: clicker.autoGain = Time.deltaTime * 87000f; break;
                    case 6: clicker.autoGain = Time.deltaTime * 100000f; break;
                    case 7: clicker.autoGain = Time.deltaTime * 106000f; break;
                    case 8: clicker.autoGain = Time.deltaTime * 145000f; break;
                    case 9: clicker.autoGain = Time.deltaTime * 200000f; break;
                }
            }
            clicker.Score += clicker.autoGain;

            bubbletimer += clicker.autoGain;

            if (bubbletimer >= 1f)
            {
                clicker.SpawnSpeechBubbles();
                bubbletimer = 0f;
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
    
    public void SunnyCaramel()
    {
        if (!shopItems[0].maxed && !isLetterActive && clicker.Score >= shopItems[0].prices[shopItems[0].index])
        {
            switch (shopItems[0].index)
            {
                case 0:
                    clicker.Gain += 2;
                    break;
                case 1:
                    clicker.Gain += 5;
                    break;
                case 2:
                    clicker.Gain += 10;
                    shopItems[1].unlocked = true;
                    break;
                case 3:
                    clicker.Gain += 20;
                    break;
                case 4:
                    clicker.Gain += 80;
                    break;
                case 5:
                    clicker.Gain += 100;
                    break;
                case 6:
                    clicker.Gain += 140;
                    break;
                case 7:
                    clicker.Gain += 160;
                    break;
                case 8:
                    clicker.Gain += 180;
                    break;
                case 9:
                    clicker.Gain += 200;
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
        if (!shopItems[1].maxed && !isLetterActive && shopItems[1].unlocked && clicker.Score >= shopItems[1].prices[shopItems[1].index])
        {
            switch (shopItems[1].index)
            {
                case 0:
                    autoGainUnlocked = true;
                    break;
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
        if (!shopItems[2].maxed && !isLetterActive && clicker.Score >= shopItems[2].prices[shopItems[2].index] && shopItems[2].unlocked)
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
        if (!shopItems[3].maxed && !isLetterActive && shopItems[3].unlocked && clicker.Score >= shopItems[3].prices[shopItems[3].index])
        {
            switch (shopItems[3].index)
            {
                case 0:
                    clicker.Gain += 50;
                    break;
                case 1:
                    clicker.Gain += 100;
                    break;
                case 2:
                    clicker.Gain += 250;
                    break;
                case 3:
                    clicker.Gain += 500;
                    break;
                case 4:
                    clicker.Gain += 800;
                    break;
                case 5:
                    clicker.Gain += 1000;
                    shopItems[4].unlocked = true;
                    break;
                case 6:
                    clicker.Gain += 1250;
                    break;
                case 7:
                    clicker.Gain += 1500;
                    break;
                case 8:
                    clicker.Gain += 2000;
                    break;
                case 9:
                    clicker.Gain += 3000;
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
        if (!shopItems[4].maxed && !isLetterActive && shopItems[4].unlocked && clicker.Score >= shopItems[4].prices[shopItems[4].index])
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
        if (!shopItems[5].maxed && !isLetterActive && shopItems[5].unlocked && clicker.Score >= shopItems[5].prices[shopItems[5].index])
        {
            switch (shopItems[5].index)
            {
                case 0:
                    clicker.Gain += 500;
                    break;
                case 1:
                    clicker.Gain += 700;
                    break;
                case 2:
                    clicker.Gain += 1000;
                    break;
                case 3:
                    clicker.Gain += 1400;
                    break;
                case 4:
                    clicker.Gain += 2000;
                    break;
                case 5:
                    clicker.Gain += 2600;
                    break;
                case 6:
                    clicker.Gain += 3100;
                    break;
                case 7:
                    clicker.Gain += 4000;
                    break;
                case 8:
                    clicker.Gain += 4500;
                    break;
                case 9:
                    clicker.Gain += 6000;
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
            clicker.Gain = 0;
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
            clicker.Gain = 0;
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
            case 2:
                letterAnims[3].SetTrigger("send1");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 3:
                letterAnims[5].SetTrigger("send1");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 5:
                letterAnims[1].SetTrigger("send1");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 6:
                letterAnims[2].SetTrigger("send1");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 9:
                letterAnims[0].SetTrigger("send1");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 12:
                letterAnims[5].SetTrigger("send2");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 13:
                letterAnims[5].SetTrigger("send3");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 15:
                letterAnims[3].SetTrigger("send4");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 16:
                letterAnims[2].SetTrigger("send2");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 18:
                letterAnims[0].SetTrigger("send2");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 20:
                letterAnims[4].SetTrigger("send1");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 22:
                letterAnims[2].SetTrigger("send3");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 23:
                letterAnims[3].SetTrigger("send3");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 25:
                letterAnims[1].SetTrigger("send2");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 26:
                letterAnims[4].SetTrigger("send2");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 28:
                letterAnims[0].SetTrigger("send3");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 30:
                letterAnims[1].SetTrigger("send3");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 31:
                letterAnims[4].SetTrigger("send5");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 33:
                letterAnims[5].SetTrigger("send4");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 34:
                letterAnims[5].SetTrigger("send5");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 35:
                letterAnims[5].SetTrigger("send6");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 36:
                letterAnims[4].SetTrigger("send4");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 37:
                letterAnims[2].SetTrigger("send7");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 38:
                letterAnims[3].SetTrigger("send5");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 42:
                letterAnims[1].SetTrigger("send4");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 43:
                letterAnims[2].SetTrigger("send4");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 44:
                letterAnims[2].SetTrigger("send5");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 45:
                letterAnims[2].SetTrigger("send6");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 46:
                letterAnims[0].SetTrigger("send4");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 47:
                letterAnims[3].SetTrigger("send6");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 48:
                letterAnims[4].SetTrigger("send6");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 49:
                letterAnims[3].SetTrigger("send7");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 50:
                letterAnims[4].SetTrigger("send3");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
            case 51:
                letterAnims[4].SetTrigger("send7");
                envelopeAudioSource.PlayOneShot(envelopeSound);
                break;
        }
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
