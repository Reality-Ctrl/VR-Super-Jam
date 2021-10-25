using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnLetter : MonoBehaviour
{
    [SerializeField] Transform point;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Letter")
        {
            other.gameObject.transform.position = point.position;
        }
    }
}
