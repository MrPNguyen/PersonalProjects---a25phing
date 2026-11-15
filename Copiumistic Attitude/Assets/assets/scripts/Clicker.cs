using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Clicker : MonoBehaviour
{
    public double Score;
    public double autoGain;
    public int Gain;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject speechBubbles;
    [SerializeField] private float duration;
    [SerializeField] private float riseAmount;
    [SerializeField] private List<Sprite> speechBubblesNeutralList;
    
    [SerializeField] private List<Sprite> speechBubblesNegativeList;
    public List<Sprite> speechBubblesPositiveList;

    private void Start()
    {
        Gain = 1;
        Score = 0f;
    }

    private void Update()
    {
        scoreText.text = Math.Floor(Score).ToString();
        if (Score < 0)
        {
            Score = 0;
        }
    }

    public void ScoreGain()
    {
        Score += Gain;
        scoreText.text = Score.ToString();
        SpawnSpeechBubbles();
    }

    public void SpawnSpeechBubbles()
    {
        StartCoroutine(ScoreGainBehavoiurroutine());
    }

    private IEnumerator ScoreGainBehavoiurroutine()
    {
        GameObject text = Instantiate(speechBubbles, transform);
        text.transform.SetSiblingIndex(6);
        
        RectTransform rect = text.GetComponent<RectTransform>();
        Vector2 startpos = rect.anchoredPosition = new Vector2(
            Random.Range(-170f, 130f),
            0f
        );
        
        float randomSize = Random.Range(0.3f, 1.5f);
        rect.localScale = new Vector2(
            randomSize,
            randomSize
        );
        
        Image img = text.GetComponent<Image>();
        float startOpacity = img.color.a;
        

        int rand =  Random.Range(0, 3);
        if (speechBubblesPositiveList.Count > 0)
        {
            if (rand == 0)
            {
                img.sprite = speechBubblesNegativeList[Random.Range(0, speechBubblesNegativeList.Count - 1)];
            }
            else if (rand == 1)
            {
                img.sprite = speechBubblesNeutralList[Random.Range(0, speechBubblesNeutralList.Count - 1)];
            }
            else
            {
                img.sprite = speechBubblesPositiveList[Random.Range(0, speechBubblesPositiveList.Count - 1)];
            }
        }
        else
        {
            if (rand == 0)
            {
                img.sprite = speechBubblesNegativeList[Random.Range(0, speechBubblesNegativeList.Count - 1)];
            }
            else if (rand == 1)
            {
                img.sprite = speechBubblesNeutralList[Random.Range(0, speechBubblesNeutralList.Count - 1)];
            }
        }
        
        
        float time = 0;
        while (time < duration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startOpacity, 0f, time / duration);
            img.color = new Color(1, 1, 1, alpha);
            
            rect.anchoredPosition = startpos + new Vector2(0f, riseAmount * time);
            yield return null;
        }
        
        img.color = new Color(1, 1, 1, 0);
        Destroy(text.gameObject);
    }
    
}
