using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Cat : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject catInfo;
    [SerializeField] private GameObject sendCatOutText;

    private void Start()
    {
        catInfo.gameObject.SetActive(false);
    }

    public void CatOut()
    {
        anim.SetBool("walkAway", true);
        anim.SetBool("walkBack", false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        anim.SetBool("standing", true);
        sendCatOutText.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        anim.SetBool("standing", false);
        sendCatOutText.SetActive(false);
    }
}
