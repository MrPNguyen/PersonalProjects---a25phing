using UnityEngine;
using UnityEngine.SceneManagement;

public class Prologue : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    public void PlayWelcome()
    {
        audioSource.Play();
    }

    public void TransitionToGame()
    {
        SceneManager.LoadScene("MainGame", LoadSceneMode.Single);
    }
}
