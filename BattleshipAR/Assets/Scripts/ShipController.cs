using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Author: Konstantin Regenhardt*/
//This script enables selecting the ships.

public class ShipController : MonoBehaviour {

    [HideInInspector]
    public bool selectShip;  //Accessed by Playercontroller and TileFX
    [HideInInspector]
    public int shipsLeft;   //Accessed and set by Gamecontroller

    private bool printed;

	// Use this for initialization
	void Start () {
        selectShip = false;
        printed = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseUp()
    {
        if(shipsLeft > 0)
        {
            selectShip = true;
        }
    }

    private void OnMouseOver()
    {
        if (!printed)
        {
            print("Ships left: " + shipsLeft);
            printed = true;
        }
    }

    private void OnMouseExit()
    {
        printed = false;
    }
}
