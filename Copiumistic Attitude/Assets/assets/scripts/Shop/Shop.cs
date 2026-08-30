using UnityEngine;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [HideInInspector] public bool shopIsOpen;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip openSound;

    public void OpenShop()
    {
        if (!shopIsOpen)
        {
            animator.SetBool("open", true);
            animator.SetBool("close", false);
            
            audioSource.PlayOneShot(openSound);
            shopIsOpen = true;
        }
        else
        {
            CloseShop();
        }
        
    }

    public void CloseShop()
    {
        animator.SetBool("open", false);
        animator.SetBool("close", true);
            
        audioSource.PlayOneShot(openSound);
        shopIsOpen = false;
    }
}
