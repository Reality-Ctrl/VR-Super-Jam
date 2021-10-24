using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowNews : MonoBehaviour
{
    [SerializeField] TMP_Text[] news_places;


    public void ResetNews()
    {
        for (int i = 0; i < news_places.Length; i++)
        {
            news_places[i].text = "";
        }
    }

    public void AddNewsToDesk(string news)
    {
        for (int i = 0; i < news_places.Length; i++)
        {
            if (news_places[i].text == "")
            {
                news_places[i].text = news;
                break;
            }
        }
    }
}
