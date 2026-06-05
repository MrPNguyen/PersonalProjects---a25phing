using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour, 
    IPointerEnterHandler, 
    IPointerExitHandler, 
    IPointerClickHandler
{
    [SerializeField] private float delay;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1.08f, 1.08f, 1.08f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(leverFlicked());
    }

    IEnumerator leverFlicked()
    {
        anim.SetBool("down", true);
        yield return new WaitForSeconds(delay);
        anim.SetBool("down", false);
    }
}
