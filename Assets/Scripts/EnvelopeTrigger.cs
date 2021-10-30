using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class EnvelopeTrigger : MonoBehaviour
{
    [SerializeField] GameObject root;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag is "Surguch")
        {
            other.gameObject.GetComponent<SurguchController>().ChangeState(root);
            Destroy(other.gameObject.GetComponent<Throwable>());
        }
    }
}
