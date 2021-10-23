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
            gameObject.transform.rotation = parent.transform.rotation;
            gameObject.transform.Rotate(90, 0, 0);
            can = false;
        }
    }

    public void Deformate()
    {
        NormalState.SetActive(false);
        SecondState.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "HeatedStamp")
        {
            Deformate();
        }
    }
}
