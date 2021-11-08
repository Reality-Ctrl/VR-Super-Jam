using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPlayer : MonoBehaviour
{
    [SerializeField] private DayManager dayManager;

    private void Awake()
    {
        dayManager.onNewDayStart.AddListener(() => onNewDay());
    }

    private void onNewDay()
    {

    }
}
