using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeactivateLetter : MonoBehaviour
{
   private Animator paper;
   [SerializeField] private Image info;
   [HideInInspector] public Sprite img;

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

   public void SetPaper()
   {
      info.sprite = img;
   }
}
