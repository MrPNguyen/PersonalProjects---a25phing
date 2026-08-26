using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CatIcon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator anim;
    [SerializeField] private GameObject sendCatOutText;

    private void Start()
    {
        anim = GetComponent<Animator>();
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
