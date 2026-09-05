using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cat : MonoBehaviour
{
    private float cattimer;
    private int sentOutAmount;
    [SerializeField] private Animator anim;
    [SerializeField] private Clicker clicker;
    [SerializeField] private GameObject catInfo;
    [SerializeField] private TextMeshProUGUI catInfoText;

    private void Start()
    {
        cattimer = 40f;
        sentOutAmount = 0;
        catInfo.gameObject.SetActive(false);
    }

    void Update()
    {
    }
    public void CatOut()
    {
        StartCoroutine(SendCatOut());
    }
    private IEnumerator SendCatOut()
    {
        anim.SetBool("walkAway", true);
        anim.SetBool("walkBack", false);
        
        if (sentOutAmount <= 4)
        {
            yield return new WaitForSeconds(cattimer);

            float catGain = Random.Range(100000f, 1000000f);
            

            anim.SetBool("walkAway", false);
            anim.SetBool("walkBack", true);
            
            cattimer +=  20f;
            sentOutAmount++;
            Debug.Log(sentOutAmount);
            
            yield return new WaitForSeconds(2f);
            clicker.Score += catGain ;
            catInfo.gameObject.SetActive(true);
            catInfoText.text = $"Hey your cat has returned and has found you {Mathf.FloorToInt(catGain)}";
            
            yield return new WaitForSeconds(7.0f);
            catInfo.gameObject.SetActive(false);
        }
    }

    public void TurnOffCatInfo()
    {
        catInfo.gameObject.SetActive(false);
    }
}
