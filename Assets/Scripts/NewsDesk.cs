using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class NewsDesk : MonoBehaviour
{
    [SerializeField] private Stack<string> news = new Stack<string>();

    public void AddNewsOnNextDay(string news)
    {
        this.news.Push(news);
    }
}
