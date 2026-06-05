using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Clicker : MonoBehaviour
{
    public float Score;
    public int gain;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject speechBubbles;
    [SerializeField] private float duration;
    [SerializeField] private float riseAmount;

    private void Start()
    {
        gain = 1;
        Score = 0f;
    }

    private void Update()
    {
        scoreText.text = Mathf.FloorToInt(Score).ToString();
        if (Score < 0)
        {
            Score = 0;
        }
    }

    public void ScoreGain()
    {
        Score += gain;
        scoreText.text = Score.ToString();
        StartCoroutine(ScoreGainBehavoiurroutine());
    }

    private IEnumerator ScoreGainBehavoiurroutine()
    {
        GameObject text = Instantiate(speechBubbles, transform);

        RectTransform rect = text.GetComponent<RectTransform>();
        Vector2 startpos = rect.anchoredPosition = new Vector2(
            Random.Range(-150f, 150f),
            0f
        );
        
        float randomSize = Random.Range(0.3f, 2f);
        Vector2 startSize = rect.localScale = new Vector2(
            randomSize,
            randomSize
        );
        
        Image img = text.GetComponent<Image>();
        float startOpacity = img.color.a;

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
