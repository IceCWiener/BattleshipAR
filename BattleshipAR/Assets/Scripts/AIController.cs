using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {

    private GameObject playerField;
    private bool phase2;
    private bool shipsPlaced;

    private float extentsX;
    private float extentsZ;

    private GameObject gameController;
    private GameController gameControllerScript;

    private int shipsLeftTotal;

    [HideInInspector]
    public int ship1Left;  //To be set by GameController
    [Range(0, 1)]
    public double blockPlaceProbability;
    
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
        if (!shipsPlaced)  //AI places its ships after the player emptied their inventory.
        {
            //print("ExtentsXZ: " + extentsX + " " + extentsZ);
                                 
            for (float i = -extentsX + 1; i < extentsX; i++)
            {
                for (float j = -extentsZ + 1; j < extentsZ; j++)
                {
                    print("For-Loop: " + i + " " + j);

                    bool placeBlock1;
                    if (Random.value > blockPlaceProbability)
                    {
                       placeBlock1 = true;
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
                        for (float x = -1; !placeBlock2;)
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
                                break;
                            }
                        }

                        print("Block placed");
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
                if (shipsPlaced) { break; }
            }
            
        }
	}
}
