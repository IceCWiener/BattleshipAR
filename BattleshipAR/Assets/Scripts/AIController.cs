﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Author: Konstantin Regenhardt*/
public class AIController : MonoBehaviour {

    private GameObject playerField;
    private bool phase2;
    private bool shipsPlaced;

    private float extentsX;
    private float extentsZ;

    private GameObject gameController;
    private GameController gameControllerScript;
    [HideInInspector]
    public int shipsLeftTotal;

    [HideInInspector]
    public int ship1Left;  //To be set by GameController
    [Range(0, 1)]
    public double blockPlaceProbability;
    [Range(0, 1)]
    public double attackProbability;
    
    // Use this for initialization
    void Start () {
        shipsPlaced = false;
        playerField = GameObject.FindGameObjectWithTag("PlayerField");

        gameController = GameObject.FindGameObjectWithTag("GameController");
        gameControllerScript = gameController.GetComponent<GameController>();

        extentsX = playerField.GetComponent<Renderer>().bounds.extents.x;    //extents = half the boardsize
        extentsZ = playerField.GetComponent<Renderer>().bounds.extents.z;
    }
	
	// Update is called once per frame
	void Update () {
        phase2 = gameControllerScript.phase2;

        shipsLeftTotal = ship1Left; //Sum of all ships left in the AI inventory.
        if (!shipsPlaced && phase2)  //AI places its ships after the player emptied their inventory and sets playerTurn in GameController to true.
        {
            //print("ExtentsXZ: " + extentsX + " " + extentsZ);
                                 
            for (float i = -extentsX + 1; i < extentsX; i++)
            {
                for (float j = -extentsZ + 1; j < extentsZ; j++)
                {
                    print("For-Loop: " + i + " " + j);

                    bool placeBlock1;
                    if (Random.value < blockPlaceProbability)
                    {
                       placeBlock1 = true;
                       gameControllerScript.aiActiveShipBlocks++;
                    }
                    else
                    {
                       placeBlock1 = false;
                    }

                    if (placeBlock1)
                    {
                        bool placeBlock2 = false;
                        GameObject tile = GameObject.Find("TileRadar " + i.ToString() + " " + j.ToString() + "(Clone)");
                        tile.GetComponent<TileRadarController>().hasShipBlock = true;
                        print("Block placed");

                        /*for (float x = -1; !placeBlock2;) //A more random placement of the second block does not seem to work yet.
                        {
                            x = Mathf.Round(x + Random.Range(0, 2));
                            for(float y = -1; !placeBlock2;)
                            {
                                y = Mathf.Round(y + Random.Range(0, 2));

                                tile = GameObject.Find("TileRadar " + i + x.ToString() + " " + j + y.ToString() + "(Clone)");
                                if (tile != null)
                                {
                                    placeBlock2 = true;
                                    tile.GetComponent<TileRadarController>().hasShipBlock = true;
                                    print("Second AIshipBlock" + tile.name);
                                }
                                placeBlock2 = true;
                                break;
                            }
                        }*/

                        for(float x = -1; x < 2; x++)
                        {
                            for(float y = -1; y < 2; y++)
                            {
                                float h = x + i;
                                float k = y + j;
                                tile = GameObject.Find("TileRadar " + h.ToString() + " " + k.ToString() + "(Clone)");

                                if(tile == null || h == 0 ^ k == 0)
                                {
                                    continue;
                                }
                                
                                tile.GetComponent<TileRadarController>().hasShipBlock = true;
                                placeBlock2 = true;
                                gameControllerScript.aiActiveShipBlocks++;
                                break;
                                
                            }
                            if (placeBlock2) { break; }
                        }

                        ship1Left--;
                        shipsLeftTotal = ship1Left;
                        print("shipsLeftTotal: " + shipsLeftTotal);

                        if(shipsLeftTotal < 1)
                        {
                           shipsPlaced = true;
                           break;
                        }
                    }
                }
                if (shipsPlaced) {
                    gameControllerScript.playerTurn = true;
                    break;
                }
            }
            
        }

        while (gameControllerScript.aiTurn) //AI takes turns attacking the player.
        {
            for (float i = -extentsX + 1; i < extentsX; i++)
            {
                for (float j = -extentsZ + 1; j < extentsZ; j++)
                {
                    GameObject tile = GameObject.Find("TileField " + i.ToString() + " " + j.ToString() + "(Clone)");
                    bool attack;
                    if (Random.value < attackProbability && !tile.GetComponent<TileFieldController>().miss && !tile.GetComponent<TileFieldController>().shipBlockDestroyed) //Only attackable when there has been no attack on the tile before.
                    {
                        attack = true;
                        gameControllerScript.playerTurn = true;
                    }
                    else
                    {
                        attack = false;
                    }
                    if (attack)
                    {
                        if (tile.GetComponent<TileFieldController>().hasShipBlock)
                        {
                            tile.GetComponent<TileFieldController>().shipBlockDestroyed = true;
                            gameControllerScript.playerActiveShipBlocks--;
                        }
                        else
                        {
                            tile.GetComponent<TileFieldController>().miss = true;
                        }
                        gameControllerScript.aiTurn = false;
                        break;
                    }
                    if (!gameControllerScript.aiTurn) { break; }
                }
                if (!gameControllerScript.aiTurn) { break; }
            }
            if (!gameControllerScript.aiTurn) { break; }
        }
	}
}
