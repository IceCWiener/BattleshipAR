using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Author: Konstantin Regenhardt*/
//This script enlarges the GameObject it is attached to and highlights it while the player clicks.

public class TileFX : MonoBehaviour
{

    //public Material material;
    //public Material highlight;

    //[Range(0, 1)]
    //public float scaleFactor;

    [Range(0, 10)]
    public float highlightColorIntensity;

    public Color clickColor;
    public Color hoverChoiceCol;    //Color that appears when you hover the mouse over the newly displayed choices.
    public GameObject shipBlock;

    //Hidden public variables are to be accessed by the Shipcontroller, so it doesn´t have to go through the logicsystem twice.
    [HideInInspector]
    public bool ship1selected;
    [HideInInspector]
    public bool choice1Ship1;    //Equals true after the player made the first choice of where to place their ship.
    //TilesFX is unique for every tile, so choices made have to be set and got from the global PlayerController.
    [HideInInspector]
    public bool chosen1Ship1;
    [HideInInspector]
    public bool setFirstBlock;

    private Material current;
    private Color original;

    private GameObject ship1;
    private ShipController shipController1;

    private GameObject playerController;
    private PlayerController playerControllerScript;

    private GameObject gameController;
    private GameController gameControllerScript;
    private bool phase1;

    private GameObject player;
    private float extentsX;
    private float extentsZ;

    private Transform trans;
    private float scaleX;
    private float scaleY;
    private float scaleZ;
    private float posX;
    //private float posY;
    private float posZ;


    // Use this for initialization
    void Start()
    {
        current = GetComponent<Renderer>().material;
        original = current.color;

        trans = GetComponent<Transform>();
        //scaleX = trans.localScale.x;
        //scaleY = trans.localScale.y;
        //scaleZ = trans.localScale.z;
        posX = trans.transform.position.x;
        //posY = trans.transform.position.y;
        posZ = trans.transform.position.z;

        ship1 = GameObject.FindGameObjectWithTag("Ship1");
        shipController1 = ship1.GetComponent<ShipController>();

        playerController = GameObject.FindGameObjectWithTag("PlayerController");
        playerControllerScript = playerController.GetComponent<PlayerController>();

        gameController = GameObject.FindGameObjectWithTag("GameController");
        gameControllerScript = gameController.GetComponent<GameController>();

        player = playerControllerScript.playerField;
        extentsX = player.GetComponent<Renderer>().bounds.extents.x;    //extents = half the boardsize
        extentsZ = player.GetComponent<Renderer>().bounds.extents.z;
    }

    // Update is called once per frame
    void Update()
    {
        ship1selected = shipController1.selectShip;
        choice1Ship1 = playerControllerScript.choice1Ship1;
        chosen1Ship1 = playerControllerScript.chosen1Ship1;
        phase1 = gameControllerScript.phase1;
    }

    private void OnMouseEnter()
    {
        //trans.localScale = new Vector3(scaleX + scaleFactor, scaleY + scaleFactor, scaleZ + scaleFactor); //Enlargens the tile
        if (phase1)
        {
            if (!choice1Ship1)
            {
                current.color = original + new Color(highlightColorIntensity, highlightColorIntensity, highlightColorIntensity);
            }

            if (ship1selected && !choice1Ship1)
            {
                for (float i = -1; i < 2; i++)
                {
                    for (float j = -1; j < 2; j++)
                    {
                        float kernelX = i + posX;
                        float kernelZ = j + posZ;
                        GameObject tile = GameObject.Find("TileField " + kernelX.ToString() + " " + kernelZ.ToString() + "(Clone)");

                        if (tile == null)
                        {
                            continue;
                        }
                        if (i == 0 ^ j == 0)
                        {
                            tile.GetComponent<Renderer>().material.color = original + new Color(highlightColorIntensity, highlightColorIntensity, highlightColorIntensity);
                        }
                    }
                }
            }

            if (ship1selected && choice1Ship1 && current.color == original + new Color(highlightColorIntensity, highlightColorIntensity, highlightColorIntensity))
            {
                current.color = hoverChoiceCol;
            }
        }

    }

    private void OnMouseExit()
    {
        //GetComponent<Transform>().localScale = new Vector3(scaleX, scaleY, scaleZ);   //Sets tile back to original size
        if (phase1)
        {
            if (!choice1Ship1)
            {
                current.color = original;
            }

            if (ship1selected && !choice1Ship1)
            {
                for (float i = -1; i < 2; i++)
                {
                    for (float j = -1; j < 2; j++)
                    {
                        float kernelX = i + posX;
                        float kernelZ = j + posZ;
                        GameObject tile = GameObject.Find("TileField " + kernelX.ToString() + " " + kernelZ.ToString() + "(Clone)");

                        if (tile == null)
                        {
                            continue;
                        }
                        if (i == 0 ^ j == 0)
                        {
                            tile.GetComponent<Renderer>().material.color = original;
                        }
                    }
                }
            }

            if (ship1selected && choice1Ship1 && current.color == hoverChoiceCol)
            {
                current.color = original + new Color(highlightColorIntensity, highlightColorIntensity, highlightColorIntensity);
            }
        }
    }

    private void OnMouseDown()
    {
        //current = highlight;
        if (phase1)
        {
            if (!choice1Ship1)
            {
                current.color = clickColor;
            }

            if (ship1selected && !choice1Ship1)
            {
                playerControllerScript.choice1Ship1 = true;
            }
        }
    }

    private void OnMouseUp()
    {
        //current = material;
        if (phase1)
        {
            if (!choice1Ship1)
            {
                current.color = original + new Color(highlightColorIntensity, highlightColorIntensity, highlightColorIntensity);
            }

            if (choice1Ship1 && !chosen1Ship1)       //Shows selectionfield for second choice of ship1 and sets first ship block.
            {
                current.color = original;
                for (float i = -1; i < 2; i++)
                {
                    for (float j = -1; j < 2; j++)
                    {
                        float kernelX = i + posX;
                        float kernelZ = j + posZ;
                        GameObject tile = GameObject.Find("TileField " + kernelX.ToString() + " " + kernelZ.ToString() + "(Clone)");

                        if (tile == null)
                        {
                            continue;
                        }
                        if (i == 0 ^ j == 0)
                        {
                            tile.GetComponent<Renderer>().material.color = original + new Color(highlightColorIntensity, highlightColorIntensity, highlightColorIntensity);
                        }
                        if (i == 0 && j == 0)
                        {
                            Instantiate(shipBlock, new Vector3(tile.transform.position.x, shipBlock.transform.position.y, tile.transform.position.z), Quaternion.identity);
                            tile.GetComponent<TileFieldController>().hasShipBlock = true;
                        }
                    }
                }
                playerControllerScript.chosen1Ship1 = true;
            }

            if (current.color == hoverChoiceCol) //Ship 1 has only two segments and when they have been placed the phase resets in the GameController until the inventory is empty.
            {
                playerControllerScript.chosen1Ship1 = false;
                playerControllerScript.choice1Ship1 = false;
                shipController1.selectShip = false;
                GameObject tile = GameObject.Find("TileField " + posX.ToString() + " " + posZ.ToString() + "(Clone)");
                Instantiate(shipBlock, new Vector3(tile.transform.position.x, shipBlock.transform.position.y, tile.transform.position.z), Quaternion.identity);
                shipController1.shipsLeft--;

                for (float i = -extentsX + 1; i < extentsX; i++)
                {
                    for (float j = -extentsZ + 1; j < extentsZ; j++)
                    {
                        tile = GameObject.Find("TileField " + i + " " + j + "(Clone)");
                        tile.GetComponent<Renderer>().material.color = original;
                    }
                }
            }
        }
        
    }
}
