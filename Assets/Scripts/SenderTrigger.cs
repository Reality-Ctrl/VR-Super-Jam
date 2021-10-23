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
        if (other.tag == "Letter")
        {
            MailBag mailBag = other.gameObject.GetComponent<MailBag>();
            
            if(CityName == mailBag.letter.recipient)
            {
                PassLetter(mailBag.letter);
            }
            else if(mailBag.letter.RightButNotRightRecipient == CityName)
            {
                PassLetter(mailBag.letter, PassType.RightButNotRightRecipient);
            }
            else
            {
                PassLetter(mailBag.letter, PassType.Wrong);
            }

            Destroy(other.gameObject);
        }
    }

    private void PassLetter(Letter letter, PassType passType = PassType.Right)
    {
        if (passType == PassType.Right)
        {
            if (letter.isLastLetter)
            {
                dayManager.letterPass(letter, true);
            }
            else
            {
                dayManager.letterPass();
            }
        }
        else if(passType == PassType.RightButNotRightRecipient)
        {
            dayManager.letterPass(letter, true);
        }
        else if(passType == PassType.Wrong)
        {
            dayManager.letterPass(letter);
        }
    }

    public enum PassType
    {
        Right,
        RightButNotRightRecipient,
        Wrong
    }
}
