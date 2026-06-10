using UnityEngine;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private bool shopIsOpen;
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
            animator.SetBool("open", false);
            animator.SetBool("close", true);
            
            audioSource.PlayOneShot(openSound);
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
