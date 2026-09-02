using UnityEngine;

public class SkipCredits : MonoBehaviour
{
    [SerializeField] private float buttonTimer;
    [SerializeField] private GameObject button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        buttonTimer -= Time.deltaTime;
        Debug.Log(buttonTimer);
        if (buttonTimer <= 0)
        {
            button.SetActive(true);
        }
    }
}
