using System;
using System.Collections.Generic;
using UnityEngine;
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
    }

    [Serializable]
    public class History
    {
        public string theme = "";
        public List<Letter> letters = new List<Letter>();
        private int currentLetter = 0;

        public Letter? GetNextLetter()
        {
            if (currentLetter < letters.Count)
            {
                return letters[currentLetter++];
            }

            return null;
        }

        public bool HaveNext()
        {
            if (currentLetter < letters.Count)
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

        public List<Letter?> GetListLetters(int size)
        {
            List<Letter?> resList = new List<Letter?>(size);
            List<bool> used = new List<bool>(histories.Count);

            for (int i = 0; i < used.Capacity; i++)
            {
                used.Add(false);
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < histories.Count; j++)
                {
                    if (used[j] == true) continue;
                    if (resList.Count == size) break;
                    used[j] = true;

                    Letter? letter = histories[j].GetNextLetter();
                    if (!letter.Equals(null))
                    {
                        resList.Add(letter);
                    }
                }
                if (resList.Count == size) break;
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
    }
}
