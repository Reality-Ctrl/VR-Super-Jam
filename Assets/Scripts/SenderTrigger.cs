using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LetterSystem;

public class SenderTrigger : MonoBehaviour
{
    [SerializeField] string CityName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Letter")
        {
            Letter letter = other.gameObject.GetComponent<MailBag>().letter;
            
            if(CityName == letter.recipient)
            {
                RightPlace(letter);
            }
            else if(letter.RightButNotRightRecipient == CityName)
            {
                RightButNotRightPlace(letter);
            }
            else
            {
                WrongPlace();
            }

            Destroy(other.gameObject);
        }
    }

    private void RightPlace(Letter letter)
    {
        if (letter.isLastLetter)
        {
            //News
        }
        else
        {
            
        }
    }

    private void RightButNotRightPlace(Letter letter)
    {

    }

    private void WrongPlace()
    {

    }
}
