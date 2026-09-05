using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeactivateLetter : MonoBehaviour
{
   private Animator paper;
   [SerializeField] private Upgrades upgrades;

   void Start()
   {
      paper = GetComponent<Animator>();
   }
   public void DeactivatePaper()
   {
      StartCoroutine(closeLetter());
   }

   public void PaperIsActive()
   {
      upgrades.isLetterActive = true;
   }

   public void PaperIsInactive()
   {
      upgrades.isLetterActive = false;
   }
   
   IEnumerator closeLetter()
   {
      paper.SetTrigger("stop");

      yield return new WaitForSeconds(0.1f);
      
      paper.SetTrigger("stop");
   }
}
