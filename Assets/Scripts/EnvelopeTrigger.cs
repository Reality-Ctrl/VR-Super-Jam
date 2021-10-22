using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvelopeTrigger : MonoBehaviour
{
    [SerializeField] GameObject root;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Surguch")
        {
            other.gameObject.GetComponent<SurguchController>().ChangeState(root);
        }
    }
}
