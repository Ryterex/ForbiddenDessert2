﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{

    public GameObject flashlight;
    public Light lightComp;

    public InventoryItem fLight;

    // Start is called before the first frame update
    void Start()
    {
        flashlight = GameObject.Find("Flashlight");
        lightComp = flashlight.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F) && fLight.collected)
        {
            lightComp.enabled = !lightComp.enabled;
        }
    }
}
