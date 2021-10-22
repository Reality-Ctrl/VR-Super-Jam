using System;
using System.Collections.Generic;

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
        public List<Letter> letters;
        private int currentLetter = 0;

        public Letter? GetNextLetter()
        {
            if (currentLetter < letters.Count)
            {
                return letters[currentLetter++];
            }

            return null;
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

        public Letter? GetRandomLetter()
        {
            if (histories.Count == 0)
            {
                return null;
            }

            Letter? letter = null;
            int index = -1;

            while (letter == null)
            {
                if (index != -1)
                {
                    histories.RemoveAt(index);
                }

                index = UnityEngine.Random.Range(0, histories.Count - 1);
                letter = histories[index].GetNextLetter();
            }
            return new Letter();
        }

        public Letter? GetRandomLetter(ref List<History> histories)
        {
            if (histories.Count == 0)
            {
                return null;
            }

            Letter? letter = null;
            int index = -1;

            while (letter == null)
            {
                if (index != -1)
                {
                    histories.RemoveAt(index);
                }

                index = UnityEngine.Random.Range(0, histories.Count - 1);
                letter = histories[index].GetNextLetter();
            }
            return new Letter();
        }
        
        public List<Letter?> GetListLetters(int size)
        {
            List<Letter?> lettersRes = new List<Letter?>();
            List<History> historiesCopy = histories;

            for (int i = 0; i < size; i++)
            {
                Letter? letter = GetRandomLetter(ref historiesCopy);
                if (letter != null)
                {
                    lettersRes.Add(letter);
                }
            }

            if (lettersRes.Count == 0)
            {
                return null;
            }

            return lettersRes;
        }
    }
}
