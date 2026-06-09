using UnityEngine;
using UnityEngine.SceneManagement;

public class Transitioner : MonoBehaviour
{
    public void TransitionToCredit()
    {
        SceneManager.LoadSceneAsync("EndCredits",  LoadSceneMode.Single);
    }

    public void TurnMyselfOff()
    {
        gameObject.SetActive(false);
    }

   
}
