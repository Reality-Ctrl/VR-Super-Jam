using System;
using System.Collections;
using System.Collections.Generic;
using LetterSystem;
using UnityEngine;
using UnityEngine.Events;

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

    public UnityEvent onNewDayStart = new UnityEvent();

    private void Awake()
    {
        onNewDayStart.AddListener(() => StartNewDay());
    }

    private void Start()
    {
        onNewDayStart.Invoke();
    }

    public void letterPass(Letter letter, bool removeHistoryLine = false, PassType passType = PassType.Right)
    {
        Debug.Log($"Letter pass: {letter.title}");
        try
        {
            string[] newStrings = letter.news.Split('#');

            if (passType == PassType.Right)
            {
                newsDesk.AddNewsOnNextDay(newStrings[0]);
            }
            else if (passType == PassType.RightButNotRightRecipient)
            {
                newsDesk.AddNewsOnNextDay(newStrings[1]);
            }
            else if (passType == PassType.Wrong)
            {
                newsDesk.AddNewsOnNextDay(newStrings[2]);
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }


        if (removeHistoryLine)
        {
            RemoveHistoryLine(letter.title);
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
        Debug.Log("Ask to stop day");
        if (CanStopDay())
        {
            onNewDayStart.Invoke();
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
        mailBag.dayManager = this;
    }

    private void RemoveHistoryLine(string historyTheme)
    {
        letterMachine.RemoveThemeOfLetters(historyTheme);
    }
}

public enum PassType
{
    Right,
    RightButNotRightRecipient,
    Wrong
}
