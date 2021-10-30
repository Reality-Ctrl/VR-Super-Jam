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
            other.gameObject.transform.parent = gameObject.transform;
            other.gameObject.GetComponent<Animator>().SetBool("Pipe1", true);

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

            if (mailBag is IDetachable)
            {
                ((IDetachable) mailBag).Detach();
            }

            // Destroy(other.gameObject); //�������� ��� ����� �������� �����
        }
    }

    private void PassLetter(Letter letter, PassType passType = PassType.Right)
    {
        if (passType == PassType.Right)
        {
            dayManager.letterPass(letter);
        }
        else if(passType == PassType.RightButNotRightRecipient)
        {
            dayManager.letterPass(letter, true, PassType.RightButNotRightRecipient);
        }
        else if(passType == PassType.Wrong)
        {
            dayManager.letterPass(letter, true, PassType.Wrong);
        }
    }
}
