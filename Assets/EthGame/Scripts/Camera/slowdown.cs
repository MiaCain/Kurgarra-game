﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowdown : MonoBehaviour
{
    public float floooo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = floooo;
    }
}
