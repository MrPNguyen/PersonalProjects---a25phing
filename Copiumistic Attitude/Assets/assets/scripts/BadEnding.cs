using UnityEngine;

public class BadEnding : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip chairClip;
    [SerializeField] private AudioClip ropeClip;

    public void PlayChair()
    {
        audioSource.PlayOneShot(chairClip);
    }

    public void PlayRope()
    {
        audioSource.PlayOneShot(ropeClip);
    }
}
