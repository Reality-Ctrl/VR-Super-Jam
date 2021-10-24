using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(Door))]
public class ExitScript : MonoBehaviour
{
    private Door door;
    [SerializeField] private DayManager dayManager;
    [SerializeField] private NotificationPlate exitNotificationPlate;

    [SerializeField] private string cantExitNotify;
    [SerializeField] private string tryAggainNotify;

    private const int timerSec = 15;
    private CancellationTokenSource cancellationToken;

    private void Awake()
    {
        door = this.GetComponent<Door>();
    }

    public void ClickOnKnob()
    {
        if (dayManager.CanStopDay())
        {
            if (door.isDoorOpen()) //Дверь уже приоткрыта, человек соглашается выйти на ружу.
            {
                cancellationToken.Cancel();
                dayManager.StopDay();
            }
            else //Дверь ещё закрыта, нужно нажать что бы увидть уведомление о выходе. 
            {
                exitNotificationPlate.DrawNotification(tryAggainNotify);
                exitNotificationPlate.ShowPlate();
                cancellationToken = new CancellationTokenSource();
                StartCoroutine(Timer());
            }
        }
        else
        {
            exitNotificationPlate.DrawNotification(cantExitNotify);
            exitNotificationPlate.ShowPlate();
        }
    }

    public IEnumerator Timer()
    {
        int remaningTime = timerSec;
        while (true)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                door.Close();
                yield break;
            }

            if (remaningTime-- < 0)
            {
                door.Close();
                exitNotificationPlate.HidePlate();
                yield break;
            }

            yield return new WaitForSeconds(1);
        }
    }
}
