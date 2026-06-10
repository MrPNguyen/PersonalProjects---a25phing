using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject transition;
    [SerializeField] private Animator transitionAnim;
    [SerializeField] private MusicFadeOut musicFadeOut;

    public void StartGame()
    {
        StartCoroutine(Begin());
    }

    public void QuitGame()
    {
        StartCoroutine(End());
    }

    IEnumerator Begin()
    {
        StartCoroutine(musicFadeOut.AudioFadeOutcoroutine(2));
        transition.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(0.1f);
        
        transitionAnim.SetTrigger("play");
        
        yield return new WaitForSeconds(3f);
        
        SceneManager.LoadScene("Prologue", LoadSceneMode.Single);
    }
    
    IEnumerator End()
    {
        StartCoroutine(musicFadeOut.AudioFadeOutcoroutine(2));
        transition.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(0.1f);
        
        transitionAnim.SetTrigger("quit");
        
        yield return new WaitForSeconds(3f);
        
        Application.Quit();
    }
}
