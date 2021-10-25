using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class Stamp : MonoBehaviour
{
    [Header("Settings")] 
    [SerializeField] [Range(0f, 1f)] private float borderTagChange;
    [SerializeField] private float heatSpeed = 0.005f;
    [SerializeField] private float coolingSpeed = 0.005f;
    [SerializeField] private MeshRenderer renderer;
    [SerializeField] private Color32 maxHeatColor = new Color32(89, 8, 8, 255);
    private readonly Color32 standartColor = new Color32(0,0,0,255);
    

    private float currHeat = 0;
    private Color32 _currColor = new Color32(0, 0, 0, 255);
    private Color32 currColor
    {
        get
        {
            return _currColor;
        }
        set
        {
            renderer.materials[0].SetColor("_EmissionColor", value);
        }
    }

    private bool onFire = false;

    private void Awake()
    {
        currColor = standartColor;
    }

    private void FixedUpdate()
    {
        if (onFire)
        {
            currHeat = Mathf.Lerp(currHeat, 1f, heatSpeed);
        }
        else
        {
            currHeat = Mathf.Lerp(currHeat, 0, coolingSpeed);
        }

        currColor = Color32.Lerp(standartColor, maxHeatColor, currHeat);

        if (currHeat >= borderTagChange)
        {
            gameObject.tag = "HeatedStamp";
        }
        else
        {
            gameObject.tag = "Stamp";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fire")
        {
            onFire = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Fire")
        {
            onFire = false;
        }
    }
}
