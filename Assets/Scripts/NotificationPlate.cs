using TMPro;
using UnityEngine;

public class NotificationPlate : MonoBehaviour
{
    [SerializeField] private TMP_Text tmp;
    [SerializeField] private GameObject notificationPlateObj;

    public void DrawNotification(string notificationText)
    {
        tmp.text = notificationText;
    }

    public void ShowPlate()
    {
        notificationPlateObj.SetActive(true);
    }

    public void HidePlate()
    {
        notificationPlateObj.SetActive(false);
    }
}
