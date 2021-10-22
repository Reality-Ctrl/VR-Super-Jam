using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SetupLetter : MonoBehaviour
{
    [SerializeField] TMP_Text LetterSender;
    [SerializeField] TMP_Text LetterRecipient;
    [SerializeField] TMP_Text StoryTitle;
    [SerializeField] TMP_Text LetterText;

    private void Start()
    {
        Setup("Captain Aboba", "Serjant Aboba");
    }

    public void Setup(string sender, string recipient)
    {
        LetterSender.text = sender;
        LetterRecipient.text = recipient;
    }
}
