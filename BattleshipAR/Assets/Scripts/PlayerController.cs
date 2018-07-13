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
    private GameObject parent;

    private bool shipClick;

    public GameObject player;
    public Transform tile;

	void Start () {
        extentsX = player.GetComponent<Renderer>().bounds.extents.x;    //extents = half the boardsize
        extentsZ = player.GetComponent<Renderer>().bounds.extents.z;
        //print("BoardX: " + extentsX);
        //print("BoardZ: " + extentsZ);

        parent = GameObject.FindGameObjectWithTag("PlayerField");

        for (float i = -extentsX + 1; i < extentsX; i++)
        {
            for(float j = -extentsZ + 1; j < extentsZ; j++)
            {
                tile.name = "Tile " + i.ToString() + " " + j.ToString();
                Instantiate(tile, new Vector3(parent.transform.position.x + i, tile.transform.position.y, parent.transform.position.z + j), Quaternion.identity, parent.transform);
            }
        }

        //print("Tilewidth: " + tile.GetComponent<Renderer>().bounds.size);

        shipClick = false;

    }
	
    void Update () {
		
	}
}
