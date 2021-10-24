using System.Collections;
using System.Collections.Generic;
using LetterSystem;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    [Header("Settings")] 
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private int lettersPerDay = 3;
    private int currLetterPass = 0;
    private List<Letter?> letters;

    public LetterMachine letterMachine;
    [SerializeField] private NewsDesk newsDesk;
    [SerializeField] private GameObject mailBagPrefab;

    private void Start()
    {
        StartNewDay();
    }
    
    public void letterPass(Letter letter, bool withNews = false, bool removeHistoryLine = false)
    {
        if (withNews)
        {
            newsDesk.AddNewsOnNextDay(letter.news);
        }

        if (removeHistoryLine)
        {
            letterMachine.RemoveThemeOfLetters(letter.title);
        }

        ++currLetterPass;
        SpawnNextLetter();
    }

    private void StartNewDay()
    {
        currLetterPass = 0;
        letters = letterMachine.GetListLetters(lettersPerDay);
        SpawnNextLetter();
    }

    public void StopDay()
    {
        if (CanStopDay())
        {
            //Stop




        }
        else
        {
            Debug.LogError("Cat't stop day with leters on map");
        }
    }

    public bool CanStopDay()
    {
        return currLetterPass == letters.Count;
    }

    private void SpawnNextLetter()
    {
        if (letters.Count != 0 && currLetterPass < letters.Count)
        {
            SpawnLetter((Letter)letters[currLetterPass]);
        } //else next day (nope)
    }


    private void SpawnLetter(Letter letter)
    {
        GameObject mailBagObj = Instantiate(mailBagPrefab, spawnPosition.position, Quaternion.identity);
        MailBag mailBag = mailBagObj.GetComponent<MailBag>();
        mailBag.letter = letter;
    }
}
