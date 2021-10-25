using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[RequireComponent(typeof(ShowNews))]
public class NewsDesk : MonoBehaviour
{
    [SerializeField] private DayManager dayManager;
    [SerializeField] private Stack<string> news = new Stack<string>();
    private ShowNews showNews;

    private void Awake()
    {
        showNews = this.GetComponent<ShowNews>();
        dayManager.onNewDayStart.AddListener(() => NewDayStart());
    }

    public void AddNewsOnNextDay(string news)
    {
        this.news.Push(news);
    }

    private void NewDayStart()
    {
        showNews.ClearDesk();
        while (news.Count > 0)
        {
            //showNews.AddNewsToDesk(news.Pop());
            showNews.AddNewsToDeskRandom(news.Pop());
        }
    }
}
