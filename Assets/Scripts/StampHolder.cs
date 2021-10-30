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
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip destroyClip;
    [SerializeField] Collider leftCollider;
    [SerializeField] Collider rightCollider;
    [SerializeField] bool canOpen = true;

    private void Update()
    {
        if (interactable.attachedToHand != null)
        {
            SteamVR_Input_Sources source = interactable.attachedToHand.handType;
            if (!OpenAction[source].stateDown && LetterAnimator.GetBool("Open"))
            {
                Open();
            }
            else if (OpenAction[source].stateDown && LetterAnimator.GetBool("Open"))
            {
                Close();
            }
        }
    }

    public void Open()
    {
        if (canOpen is true) // � ��������, ��� �����, ����� �����
        {
            source.PlayOneShot(destroyClip, 1f);
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
        if (canOpen is true)
        {
            leftCollider.enabled = true;
            rightCollider.enabled = true;
            LetterAnimator.SetBool("Close", true);
            canOpen = false;
        }
    }
}
