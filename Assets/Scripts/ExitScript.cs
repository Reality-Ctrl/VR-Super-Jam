using System.Collections;
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
                exitNotificationPlate.HidePlate();
                dayManager.StopDay();
            }
            else //Дверь ещё закрыта, нужно нажать что бы увидть уведомление о выходе. 
            {
                exitNotificationPlate.DrawNotification(tryAggainNotify);
                exitNotificationPlate.ShowPlate();
                cancellationToken = new CancellationTokenSource();
                door.Open();
                StartCoroutine(CloseDoorTimer());
            }
        }
        else
        {
            exitNotificationPlate.DrawNotification(cantExitNotify);
            exitNotificationPlate.ShowPlate();
            StartCoroutine(NotifyLiveTimer());
        }
    }

    public IEnumerator CloseDoorTimer()
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
    
    public IEnumerator NotifyLiveTimer()
    {
        int remaningTime = timerSec;
        while (true)
        {
            if (remaningTime-- < 0)
            {
                exitNotificationPlate.HidePlate();
                yield break;
            }

            yield return new WaitForSeconds(1);
        }
    }
}
