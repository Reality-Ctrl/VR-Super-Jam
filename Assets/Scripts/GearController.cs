using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rope_speed;
    [SerializeField] Renderer rope;

    void FixedUpdate()
    {
        gameObject.transform.Rotate(0, speed, 0);
        rope.material.mainTextureOffset = new Vector2(rope_speed * Time.time, 0);
    }
}
