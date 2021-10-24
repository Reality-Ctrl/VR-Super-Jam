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
        //Setup("Captain Aboba", "Serjant Aboba", "Some title", "Some long text");
    }

    public void Setup(string sender, string recipient, string story_title, string story_text)
    {
        LetterSender.text = sender;
        LetterRecipient.text = recipient;
        StoryTitle.text = story_title;
        LetterText.text = story_text;
    }
}
