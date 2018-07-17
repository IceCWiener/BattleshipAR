using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*Author: Konstantin Regenhardt*/
//This script controlles all game mechanics like changing phases of placing ships and taking turn attacking the enemy.
//All variables that control rules and the like should be publicly initialized in this script.

public class GameController : MonoBehaviour {

    public int numOfShip1InInventory;

    public Text winText;
    public Text loseText;
    public Text escText;


    [HideInInspector]
    public int shipsInPlayerInventory;
    [HideInInspector]
    public int shipsInAiInventory;
    [HideInInspector]
    public bool phase1;    //Selecting and placing ships
    [HideInInspector]
    public bool phase2;    //Taking turns picking and attacking targets
    [HideInInspector]
    public bool playerTurn;
    [HideInInspector]
    public bool aiTurn;
    [HideInInspector]
    public int playerActiveShipBlocks;
    [HideInInspector]
    public int aiActiveShipBlocks;

    private GameObject ship1;
    private ShipController shipController;

    private AIController aiController;    
	// Use this for initialization
	void Start () {
        winText.text = "";
        loseText.text = "";
        escText.text = "";
        phase1 = true;
        phase2 = false;

        ship1 = GameObject.FindGameObjectWithTag("Ship1");
        shipController = ship1.GetComponent<ShipController>();
        shipController.shipsLeft = numOfShip1InInventory;

        aiController = GameObject.FindGameObjectWithTag("AIController").GetComponent<AIController>();
        aiController.ship1Left = 2;
	}
	
	// Update is called once per frame
	void Update () {
        shipsInPlayerInventory = shipController.shipsLeft;
        shipsInAiInventory = aiController.shipsLeftTotal;
        print("AIShipsTotal: " + shipsInAiInventory + " AIShipBlocks: " + aiActiveShipBlocks + " PlayerShipBlocks: " + playerActiveShipBlocks);

        if(shipsInPlayerInventory == 0)
        {
            phase1 = false;
            phase2 = true;
        }
        if(shipsInAiInventory <= 0 && aiActiveShipBlocks <= 0) //You win!
        {
            winText.text = "You Win!";
            escText.text = "Press SPACE to play again and ESC to exit";
        }
        if(shipsInAiInventory <= 0 && playerActiveShipBlocks <= 0) //AI wins!
        {
            loseText.text = "You lost the game.";
            escText.text = "Press SPACE to play again and ESC to exit";
        }

        if (Input.GetButtonDown("Exit"))
        {
            Application.Quit();
        }

        if (Input.GetButtonDown("Replay"))
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
        //print("Playerblocks: " + playerActiveShipBlocks + " AIblocks: " + aiActiveShipBlocks);
    }
}
