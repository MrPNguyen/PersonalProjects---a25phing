using UnityEngine;
using UnityEngine.EventSystems;

public class HandleTooltip : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler
{
    public Items item;

    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipUI.Instance.Show(item, item.index, item.unlocked, item.maxed);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipUI.Instance.Hide();
    }
}
