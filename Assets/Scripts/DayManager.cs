using System.Collections;
using System.Collections.Generic;
using LetterSystem;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    [Header("Settings")] 
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private int lettersPerDay = 3;
    private int currLetterPass = 0;
    private List<Letter?> letters;

    public LetterMachine letterMachine;
    [SerializeField] private NewsDesk newsDesk;
    [SerializeField] private GameObject mailBagPrefab;

    public void letterPass()
    {
        ++currLetterPass;
    }
    
    public void letterPass(Letter letter, bool withNews = false)
    {
        if (withNews)
        {
            newsDesk.AddNewsOnNextDay(letter.news);
        }
        letterMachine.RemoveThemeOfLetters(letter.title); 
        ++currLetterPass;
    }

    private void StartNewDay()
    {
        currLetterPass = 0;
        letters = letterMachine.GetListLetters(lettersPerDay);
    }

    public void StopDay()
    {
        if (currLetterPass == letters.Count)
        {
            //Stop
        }
    }

    private void SpawnLetter(Letter letter)
    {
        GameObject mailBagObj = Instantiate(mailBagPrefab, spawnPosition, Quaternion.identity);
        MailBag mailBag = mailBagObj.GetComponent<MailBag>();
        mailBag.letter = letter;
    }
}
