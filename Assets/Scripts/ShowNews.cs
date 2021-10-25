using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShowNews : MonoBehaviour
{
    [SerializeField] private NewsPaper[] news_places;

    public void ResetNews()
    {
        for (int i = 0; i < news_places.Length; i++)
        {
            news_places[i].Clear();
        }
    }

    public void AddNewsToDesk(string news)
    {
        for (int i = 0; i < news_places.Length; i++)
        {
            if (news_places[i].GetCurrText() == string.Empty)
            {
                news_places[i].Show(news);
                break;
            }
        }
    }

    public void AddNewsToDeskRandom(string news)
    {
        int countClear = 0;
        foreach (var newsPaper in news_places)
        {
            if (newsPaper.GetCurrText() == string.Empty)
            {
                countClear++;
            }
        }

        if (countClear != 0)
        {
            while (true)
            {
                int index = Random.Range(0, news_places.Length);
                if (news_places[index].GetCurrText() == String.Empty)
                {
                    news_places[index].Show(news);
                    break;
                }
            }
        }
        else
        {
            Debug.LogError("U can't add more news on desk");
        }
    }

    public void ClearDesk()
    {
        foreach (var newsPaper in news_places)
        {
            newsPaper.HideWithClear();
        }
    }
}
