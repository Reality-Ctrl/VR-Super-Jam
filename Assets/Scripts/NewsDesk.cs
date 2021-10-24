using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using TMPro;

public class NewsDesk : MonoBehaviour
{
    [SerializeField] private Stack<string> news = new Stack<string>();
    [SerializeField] TMP_Text news_desc;

    public void AddNewsOnNextDay(string news)
    {
        this.news.Push(news);
    }

    public void AddNewsToDesk(string news)
    {
        news_desc.text += "\n" + news;
    }
}
