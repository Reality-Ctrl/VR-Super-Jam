using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using LetterSystem;

public class LetterMachine : MonoBehaviour
{
    [SerializeField] private string path = "Storage_EN";
    [SerializeField] private HistoryStorage storage;

    private bool flag = true;

    private void Awake()
    {
        string absolutePath = Path.Combine(Application.dataPath, path);
        if (File.Exists(absolutePath))
        {
            string json = File.ReadAllText(absolutePath);
            storage = JsonUtility.FromJson<HistoryStorage>(json);
        }
        else
        {
            throw new Exception("Can't read Histories from file.", new FileNotFoundException());
        }
    }

    public List<Letter?> GetListLetters(int size)   //If NULL storage is empty (The letters are over)
    {
        return storage.GetListLetters(size);
    }

    private void MakeTestFile(int historiesCount, int lettersCount)
    {
        storage = new HistoryStorage();
        for (int i = 0; i < historiesCount; i++)
        {
            History history = new History();
            history.theme = i.ToString();

            for (int j = 0; j < lettersCount; j++)
            {
                Letter letter = new Letter
                {
                    title = i.ToString(),
                    from = j.ToString(),
                    recipient = j.ToString(),
                    RightButNotRightRecipient = j.ToString(),
                    text = j.ToString(),
                    news = j.ToString()
                };
                history.letters.Add(letter);
            }
            storage.histories.Add(history);
        }

        path += ".json";
        File.WriteAllText(Path.Combine(Application.dataPath, path), JsonUtility.ToJson(storage));
    }

    public IEnumerator TestCorutine()
    {
        while (true)
        {
            List<Letter?> letters = GetListLetters(3);
            if (letters.Count == 0) yield break;

            string res = String.Empty;
            foreach (var letter in letters)
            {
                res += $"Letter title {((Letter)letter).title}, Text {((Letter)letter).text} \n";
            }
            Debug.Log($"{res}");

            yield return new WaitForSeconds(1);
        }
        yield break;
    }
}
