using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class StampHolder : MonoBehaviour
{
    [SerializeField] GameObject NormalStamp;
    [SerializeField] GameObject[] BrokenStamp;
    [SerializeField] Animator LetterAnimator;
    [SerializeField] SteamVR_Action_Boolean OpenAction;
    [SerializeField] Interactable interactable;
    [SerializeField] bool canOpen = true;

    private void Update()
    {
        if (interactable.attachedToHand != null)
        {
            SteamVR_Input_Sources source = interactable.attachedToHand.handType;
            if (OpenAction[source].stateDown && LetterAnimator.GetBool("Open") == false)
            {
                LetterAnimator.SetBool("Open", true);
            }
            else if (OpenAction[source].stateDown && LetterAnimator.GetBool("Open") == true)
            {
                LetterAnimator.SetBool("Close", true);
            }
        }
    }

    public void Open()
    {
        if (canOpen)
        {
            for (int i = 0; i < BrokenStamp.Length; i++)
            {
                BrokenStamp[i].SetActive(true);
            }
            Destroy(NormalStamp);
            LetterAnimator.SetBool("Open", true);
        }
    }

    public void Close()
    {
        if (canOpen)
        {
            LetterAnimator.SetBool("Close", true);
            canOpen = false;
        }
    }
}
