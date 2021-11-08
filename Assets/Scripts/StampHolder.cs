using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class StampHolder : MonoBehaviour
{
    [SerializeField] MailBag mailBag;
    [SerializeField] GameObject NormalStamp;
    [SerializeField] GameObject[] BrokenStamp;
    [SerializeField] Animator LetterAnimator;
    [SerializeField] SteamVR_Action_Boolean OpenAction;
    [SerializeField] Interactable interactable;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip destroyClip;
    [SerializeField] Collider leftCollider;
    [SerializeField] Collider rightCollider;
    [SerializeField] bool firstOpen = true;
    public bool canOpen = true;

    private void Start()
    {
        firstOpen = true;
    }

    private void Update()
    {
        if (interactable.attachedToHand != null)
        {
            SteamVR_Input_Sources source = interactable.attachedToHand.handType;
            if (OpenAction[source].stateDown)
            {
                if (!LetterAnimator.GetBool("Open") is true)
                {
                    Open();
                }
                else
                {
                    Close();
                }
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                if (!LetterAnimator.GetBool("Open") is true)
                {
                    Open();
                }
                else
                {
                    Close();
                }
            }
        }
    }

    public void Open()
    {
        if (firstOpen is true) // я питонист, мне можно, пошел нахуй
        {
            source.PlayOneShot(destroyClip, 1f);
            for (int i = 0; i < BrokenStamp.Length; i++)
            {
                BrokenStamp[i].SetActive(true);
            }
            Destroy(NormalStamp);
            LetterAnimator.SetBool("Open", true);
            firstOpen = false;
        }
        if (firstOpen is false)
        {
            if (canOpen is true)
            {
                leftCollider.enabled = false;
                rightCollider.enabled = false;
                LetterAnimator.SetBool("Close", false);
                LetterAnimator.SetBool("Open", true);
            }
        }
        mailBag.canSend = false;
    }

    public void Close()
    {
        if (canOpen is true)
        {
            leftCollider.enabled = true;
            rightCollider.enabled = true;
            LetterAnimator.SetBool("Open", false);
            LetterAnimator.SetBool("Close", true);
        }
    }
}
