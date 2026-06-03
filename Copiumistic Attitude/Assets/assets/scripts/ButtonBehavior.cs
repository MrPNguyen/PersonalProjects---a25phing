using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour, 
    IPointerEnterHandler, 
    IPointerExitHandler, 
    IPointerClickHandler
{
    [SerializeField] private Sprite imgHover;
    [SerializeField] private Sprite imgDefault;
    [SerializeField] private Sprite imgClicked;
    
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        button.image.sprite = imgHover;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        button.image.sprite = imgDefault;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(buttonClicked());
    }

    IEnumerator buttonClicked()
    {
        button.image.sprite = imgClicked;
        yield return new WaitForSeconds(0.05f);
        button.image.sprite = imgDefault;
    }
}
