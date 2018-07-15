using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Author: Konstantin Regenhardt*/
//This script dynamically fills the field of the player with squares with a margin to the borders and each other.
//(Change tilesize in prefab)

public class PlayerController : MonoBehaviour {


    private float extentsX;
    private float extentsZ;
    private float tileSize;
    private Transform parentField;
    private Transform parentRadar;
    public GameObject playerField;
    public GameObject playerRadar;

    //private bool shipClick;
    [HideInInspector]
    public bool choice1Ship1;   //Globally displays if the player chose their first position of ship1.
    [HideInInspector]
    public bool chosen1Ship1;   //Intermidiate boolean to mark state of letting go of the mouse after a choice has been made.

    public Transform tileField;
    public Transform tileRadar;

	void Start () {
        parentField = GameObject.FindGameObjectWithTag("PlayerField").GetComponent<Transform>();    //If changed to playerField.Get... -> Error: Can't destroy Transform component of 'TileField -2 -3(Clone)'. If you want to destroy the game object, please call 'Destroy' on the game object instead. Destroying the transform component is not allowed.
        parentRadar = GameObject.FindGameObjectWithTag("PlayerRadar").GetComponent<Transform>();    //Same error

        extentsX = playerField.GetComponent<Renderer>().bounds.extents.x;    //extents = half the boardsize
        extentsZ = playerField.GetComponent<Renderer>().bounds.extents.z;
        //print("BoardX: " + extentsX);
        //print("BoardZ: " + extentsZ);
        
        for (float i = -extentsX + 1; i < extentsX; i++)
        {
            for(float j = -extentsZ + 1; j < extentsZ; j++)
            {
                tileField.name = "TileField " + i.ToString() + " " + j.ToString();
                Instantiate(tileField, new Vector3(playerField.transform.position.x + i, playerField.transform.position.y + tileField.transform.position.y, playerField.transform.position.z + j), Quaternion.identity, parentField);

                tileRadar.name = "TileRadar " + i.ToString() + " " + j.ToString();
                Instantiate(tileRadar, new Vector3(playerRadar.transform.position.x + i, playerRadar.transform.position.y + j, playerRadar.transform.position.z + tileRadar.transform.position.y), playerRadar.transform.rotation, parentRadar);
            }
        }

        //print("Tilewidth: " + tile.GetComponent<Renderer>().bounds.size);

        //shipClick = false;
        choice1Ship1 = false;
        chosen1Ship1 = false;
    }
	
    void Update () {
		
	}
}
