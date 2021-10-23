using UnityEngine;
using LetterSystem;

public class MailBag : MonoBehaviour
{
    [SerializeField] private SetupLetter setupLetter;
    [HideInInspector] public LetterMachine letterMachine;

    private Letter _letter;
    public Letter letter
    {
        set
        {
            _letter = value;
            setupLetter.Setup(value.from, value.recipient, value.title, value.text);
        }

        get
        {
            return _letter;
        }
    }
}
