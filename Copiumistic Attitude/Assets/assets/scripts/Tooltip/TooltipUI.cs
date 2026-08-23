using TMPro;
using UnityEngine;

public class TooltipUI : MonoBehaviour
{
    public static TooltipUI Instance;

    public GameObject panel;
    
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI priceText;

    private Items currentItem;

    [SerializeField] private Vector3 offset;

    void Awake()
    {
        Instance =  this;
        panel.SetActive(false);
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Mathf.Abs(Camera.main.transform.position.z - panel.transform.position.z);

        panel.transform.position = Camera.main.ScreenToWorldPoint(mousePosition) + offset;
    }

    public void Show(Items item, int index, bool unlocked, bool maxed)
    {
        currentItem = item;
        if (unlocked && !maxed)
        {
            titleText.text = item.name;
            descriptionText.text = item.description;
            priceText.text = $"${item.prices[index]}";
        }
        else
        {
            titleText.text = "???";
            descriptionText.text = "???";
            priceText.text = "???";
        }
        
        panel.SetActive(true);
    }

    public void Refresh()
    {
        if(currentItem == null)
            return;
        
        Show(currentItem, currentItem.index, currentItem.unlocked, currentItem.maxed);
    }

    public void Hide()
    {
        panel.SetActive(false);
    }
}
