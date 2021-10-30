using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LetterSystem;

public class SenderTrigger : MonoBehaviour
{
    [SerializeField] private string CityName;
    [SerializeField] private DayManager dayManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag is "Letter")
        {
            MailBag mailBag = other.gameObject.GetComponent<MailBag>();
            if (mailBag.canSend is true)
            {
                if (CityName == mailBag.letter.recipient)
                {
                    PassLetter(mailBag.letter);
                }
                else if (mailBag.letter.RightButNotRightRecipient == CityName)
                {
                    PassLetter(mailBag.letter, PassType.RightButNotRightRecipient);
                }
                else
                {
                    PassLetter(mailBag.letter, PassType.Wrong);
                }

                if (mailBag is IDetachable)
                {
                    ((IDetachable)mailBag).Detach();
                }

                other.gameObject.transform.parent = gameObject.transform;
                mailBag.PipeAnimation();
            }
        }
    }

    private void PassLetter(Letter letter, PassType passType = PassType.Right)
    {
        if (passType == PassType.Right)
        {
            dayManager.letterPass(letter);
        }
        else if (passType == PassType.RightButNotRightRecipient)
        {
            dayManager.letterPass(letter, true, PassType.RightButNotRightRecipient);
        }
        else if (passType == PassType.Wrong)
        {
            dayManager.letterPass(letter, true, PassType.Wrong);
        }
    }
}
