using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvMovemnt : MonoBehaviour
{
    [SerializeField] bool can = true;
    [SerializeField] GameObject root;
    [SerializeField] GameObject rotator;
    [SerializeField] float angle;

    void FixedUpdate()
    {
        Debug.Log(rotator.transform.rotation.x);
        if (gameObject.transform.localPosition.x > 2.46f)
        {
            angle = rotator.transform.rotation.x;
            gameObject.transform.parent = rotator.transform;
            can = false;
        }
        if (rotator.transform.rotation.x == angle - 180f)
        {
            angle = 100000f;
            gameObject.transform.parent = root.transform;
            can = true;
        }
        if (can is true)
        {
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + 0.07f, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
        }
    }
}
