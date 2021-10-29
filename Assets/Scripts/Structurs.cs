using System;
using System.Collections.Generic;
using UnityEditor;
using Random = UnityEngine.Random;

namespace LetterSystem
{
    [Serializable]
    public struct Letter
    {
        public string title;
        public string from; //City name
        public string recipient;    //City name
        public string RightButNotRightRecipient;    //City name
        public string text; //Letter text
        public string news; //If history end or u drop msg to RightButNotRightRecipient city
        [NonSerialized] public bool isLastLetter;
    }

    [Serializable]
    public class History
    {
        public string theme = "";
        public List<Letter> letters = new List<Letter>();
        private int currentLetterIndex = 0;

        public Letter? GetNextLetter()
        {
            if (currentLetterIndex < letters.Count)
            {
                Letter result = letters[currentLetterIndex];

                if (currentLetterIndex >= letters.Count - 1) //Last Letter
                {
                    result.isLastLetter = true;
                }
                else
                {
                    result.isLastLetter = false;
                }
                currentLetterIndex++;
                return result;
            }

            return null;
        }

        public bool HaveNext()
        {
            if (currentLetterIndex < letters.Count)
            {
                return true;
            }

            return false;
        }
    }

    [Serializable]
    public class HistoryStorage
    {
        public List<History> histories = new List<History>();

        public void RemoveThemeOfLetters(string theme)
        {
            for (int i = 0; i < histories.Count; i++)
            {
                if (histories[i].theme == theme)
                {
                    histories.RemoveAt(i);
                    break;
                }
            }
        }

        public List<Letter?> GetListLetters(int size)
        {
            List<Letter?> resList = new List<Letter?>(size);
            List<bool> used = new List<bool>(histories.Count);

            for (int i = 0; i < used.Capacity; i++)
            {
                used.Add(false);
            }

            while (true)
            {
                if (resList.Count == size || IsAllListTrue(used)) break;

                int randomIndex = Random.Range(0, histories.Count);
                if (used[randomIndex] == true) continue;
                used[randomIndex] = true;
                
                Letter? letter = histories[randomIndex].GetNextLetter();
                if (!letter.Equals(null))
                {
                    resList.Add(letter);
                }
            }

            return resList;
        }

        private bool IsAllListTrue(List<bool> used)
        {
            foreach (var isUsed in used)
            {
                if (isUsed == false)
                {
                    return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            string res = string.Empty;

            foreach (var history in histories)
            {
                foreach (var historyLetter in history.letters)
                {
                    res += $"History Theme: {history.theme}, Letters count: {history.letters.Count}, Letter text: {historyLetter.text}; \n";
                }
            }

            return res;
        }
    }



    internal interface IDetachable
    {
        public void Detach();
    }
}
