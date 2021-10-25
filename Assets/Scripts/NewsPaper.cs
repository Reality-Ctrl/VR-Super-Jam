using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewsPaper : MonoBehaviour
{
    [SerializeField] private TMP_Text news_place;
    [SerializeField] private GameObject paperObj;

    public void ApplyText(string newsText)
    {
        news_place.text = newsText;
    }

    public string GetCurrText()
    {
        return news_place.text;
    }

    public void Clear()
    {
        news_place.text = string.Empty;
    }

    public void Show()
    {
        paperObj.SetActive(true);
    }

    public void Show(string newsText)
    {
        ApplyText(newsText);
        Show();
    }

    public void Hide()
    {
        paperObj.SetActive(false);
    }

    public void HideWithClear()
    {
        Clear();
        Hide();
    }
}
