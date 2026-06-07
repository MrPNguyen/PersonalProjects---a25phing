using System;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Items item;
    [SerializeField] private GameObject unlockedImg;
    [SerializeField] private GameObject lockedImg;
    [SerializeField] private GameObject maxedImg;

    private void Update()
    {
        if (item.unlocked)
        {
            if (unlockedImg != null && unlockedImg != null)
            {
                unlockedImg.SetActive(true);
                lockedImg.SetActive(false);
            }
        }
        else
        {
            if (unlockedImg != null && unlockedImg != null)
            {
                unlockedImg.SetActive(false);
                lockedImg.SetActive(true);
            }
        }

        if (item.maxed)
        {
            maxedImg.SetActive(true);
        }
    }
}
