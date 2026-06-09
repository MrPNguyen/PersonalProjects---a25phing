using System.Collections;
using UnityEngine;

public class DeactivateLetter : MonoBehaviour
{
   private Animator paper;

   void Start()
   {
      paper = GetComponent<Animator>();
   }
   public void DeactivatePaper()
   {
      StartCoroutine(closeLetter());
   }

   IEnumerator closeLetter()
   {
      paper.SetTrigger("stop");

      yield return new WaitForSeconds(0.1f);
      
      paper.SetTrigger("stop");
   }
}
