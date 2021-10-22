using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class СonveyorTrigger : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Letter")
        {
            other.gameObject.transform.position += Vector3.right * Time.deltaTime;
        }
    }
}
