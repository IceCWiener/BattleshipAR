using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Author: Konstantin Regenhardt*/
//This script controlles all game mechanics like changing phases of placing ships and taking turn attacking the enemy.
//All variables that control rules and the like should be publicly initialized in this script.

public class GameController : MonoBehaviour {

    public int numOfShip1InInventory;

    [HideInInspector]
    public int numOfAllShipsLeft;
    [HideInInspector]
    public bool phase1;    //Selecting and placing ships
    [HideInInspector]
    public bool phase2;    //Taking turns picking and attacking targets
    [HideInInspector]
    public bool playerTurn;
    [HideInInspector]
    public bool aiTurn;

    private GameObject ship1;
    private ShipController shipController;
    
	// Use this for initialization
	void Start () {
        phase1 = true;
        phase2 = false;
        ship1 = GameObject.FindGameObjectWithTag("Ship1");
        shipController = ship1.GetComponent<ShipController>();
        shipController.shipsLeft = numOfShip1InInventory;

	}
	
	// Update is called once per frame
	void Update () {
        numOfAllShipsLeft = shipController.shipsLeft;
        if(numOfAllShipsLeft == 0)
        {
            phase1 = false;
            phase2 = true;
        }
	}
}
