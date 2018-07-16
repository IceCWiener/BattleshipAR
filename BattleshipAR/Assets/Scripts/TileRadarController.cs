﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRadarController : MonoBehaviour {
    
    public bool hasShipBlock;
    [HideInInspector]
    public bool shipBlockDestroyed;

    // Use this for initialization
    void Start () {
        hasShipBlock = false;
        shipBlockDestroyed = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (hasShipBlock)
        {
            GetComponent<Renderer>().material.color = Color.cyan;
        }
	}
}
