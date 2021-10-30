using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private void Start()
    {
        
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
