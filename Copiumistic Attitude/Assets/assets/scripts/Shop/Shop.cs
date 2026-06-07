using UnityEngine;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private bool shopIsOpen;

    void Update()
    {
        Debug.Log(shopIsOpen);
    }
    public void OpenShop()
    {
        if (!shopIsOpen)
        {
            animator.SetBool("open", true);
            animator.SetBool("close", false);
            shopIsOpen = true;
        }
        else
        {
            animator.SetBool("open", false);
            animator.SetBool("close", true);
            shopIsOpen = false;
        }
        
    }

    public void CloseShop()
    {
        if (shopIsOpen)
        {
           
        }
    }
}
