using System;
using System.IO;
using UnityEngine;
using LetterSystem;

public class LetterMachine : MonoBehaviour
{
    [SerializeField] private string path = "Storage_EN";
    private HistoryStorage storage;

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

    private void MakeTestFile()
    {
        storage = new HistoryStorage();
        for (int i = 0; i < 10; i++)
        {
            History history = new History();
            history.theme = i.ToString();

            for (int j = 0; j < 10; j++)
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
}
