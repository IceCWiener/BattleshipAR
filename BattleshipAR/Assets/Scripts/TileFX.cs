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

    private Material current;
    private Color original;
    private GameObject ship1;
    private ShipController shipController1;
    private bool ship1selected;

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
    }

    // Update is called once per frame
    void Update()
    {
        ship1selected = shipController1.selectShip;

    }

    private void OnMouseEnter()
    {
        //trans.localScale = new Vector3(scaleX + scaleFactor, scaleY + scaleFactor, scaleZ + scaleFactor); //Enlargens the tile
        current.color = original + new Color(highlightColorIntensity, highlightColorIntensity, highlightColorIntensity);

        if (ship1selected)
        {
            for (float i = -1; i < 2; i++)
            {
                for (float j = -1; j < 2; j++)
                {
                    float kernelX = i + posX;
                    float kernelZ = j + posZ;
                    GameObject tile = GameObject.Find("Tile " + kernelX.ToString() + " " + kernelZ.ToString() + "(Clone)");

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

    }

    private void OnMouseExit()
    {
        //GetComponent<Transform>().localScale = new Vector3(scaleX, scaleY, scaleZ);   //Sets tile back to original size
        current.color = original;

        if (ship1selected)
        {
            for (float i = -1; i < 2; i++)
            {
                for (float j = -1; j < 2; j++)
                {
                    float kernelX = i + posX;
                    float kernelZ = j + posZ;
                    GameObject tile = GameObject.Find("Tile " + kernelX.ToString() + " " + kernelZ.ToString() + "(Clone)");

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
    }

    private void OnMouseDown()
    {
        //current = highlight;
        current.color = clickColor;
    }

    private void OnMouseUp()
    {
        //current = material;
        current.color = original + new Color(highlightColorIntensity, highlightColorIntensity, highlightColorIntensity);
    }
}
