using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurguchController : MonoBehaviour
{
    [SerializeField] Rigidbody Rigidbody;
    [SerializeField] GameObject NormalState;
    [SerializeField] GameObject SecondState;
    bool can = true;

    public void ChangeState(GameObject parent)
    {
        if (can == true)
        {
            Rigidbody.isKinematic = true;
            gameObject.transform.parent = parent.transform;
            gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            NormalState.SetActive(false);
            SecondState.SetActive(true);
            can = false;
        }
    }
}
