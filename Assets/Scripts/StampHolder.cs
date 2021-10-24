using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampHolder : MonoBehaviour
{
    [SerializeField] GameObject NormalStamp;
    [SerializeField] GameObject[] BrokenStamp;
    [SerializeField] Animator LetterAnimator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Open();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Close();
        }
    }

    public void Open()
    {
        for (int i = 0; i < BrokenStamp.Length; i++)
        {
            BrokenStamp[i].SetActive(true);
        }
        Destroy(NormalStamp);
        LetterAnimator.SetBool("Open", true);
    }

    public void Close()
    {
        LetterAnimator.SetBool("Close", true);
    }
}
