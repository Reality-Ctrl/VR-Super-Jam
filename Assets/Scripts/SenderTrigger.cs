using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LetterSystem;

public class SenderTrigger : MonoBehaviour
{
    [SerializeField] private string CityName;
    [SerializeField] private NewsDesk newsDesk;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Letter")
        {
            MailBag mailBag = other.gameObject.GetComponent<MailBag>();
            
            if(CityName == mailBag.letter.recipient)
            {
                RightPlace(mailBag.letter);
            }
            else if(mailBag.letter.RightButNotRightRecipient == CityName)
            {
                RightButNotRightPlace(mailBag.letter, mailBag.letterMachine);
            }
            else
            {
                WrongPlace(mailBag.letter, mailBag.letterMachine);
            }

            Destroy(other.gameObject);
        }
    }

    private void RightPlace(Letter letter)
    {
        if (letter.isLastLetter)
        {
            newsDesk.AddNewsOnNextDay(letter.news);
        }
    }

    private void RightButNotRightPlace(Letter letter, LetterMachine leterMachine)
    {
        newsDesk.AddNewsOnNextDay(letter.news);
        leterMachine.RemoveThemeOfLetters(letter.title);
    }

    private void WrongPlace(Letter letter, LetterMachine leterMachine)
    {
        leterMachine.RemoveThemeOfLetters(letter.title);
    }
}
