using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Author: Konstantin Regenhardt*/
//This script controlles all game mechanics like changing phases of placing ships and taking turn attacking the enemy.
//All variables that control rules and the like should be publicly initialized in this script.

public class GameController : MonoBehaviour {

    public int numOfShip1InInventory;

    private GameObject ship1;
    private ShipController shipController;
    
	// Use this for initialization
	void Start () {
        ship1 = GameObject.FindGameObjectWithTag("Ship1");
        shipController = ship1.GetComponent<ShipController>();
        shipController.shipsLeft = numOfShip1InInventory;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
