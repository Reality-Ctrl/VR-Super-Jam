using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class СonveyorTrigger : MonoBehaviour
{
    [SerializeField] float speed = 2;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Letter")
        {
            other.gameObject.transform.position += Vector3.right * Time.deltaTime * speed;
        }
    }
}
