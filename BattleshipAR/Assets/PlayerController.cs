using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Author: Konstantin Regenhardt*/

public class PlayerController : MonoBehaviour {

    //This script dynamically fills the field of the player with squares with a margin to the borders and each other.
    //(Change tilesize in prefab)

    private float extentsX;
    private float extentsZ;
    private float tileSize;

    public GameObject player;
    public Transform tile;

	void Start () {
        extentsX = player.GetComponent<Renderer>().bounds.extents.x;    //extents = half the boardsize
        extentsZ = player.GetComponent<Renderer>().bounds.extents.z;
        //print("BoardX: " + extentsX);
        //print("BoardZ: " + extentsZ);

        for (float i = -extentsX + 1; i < extentsX; i++)
        {
            for(float j = -extentsZ + 1; j < extentsZ; j++)
            {
                Instantiate(tile, new Vector3(i, tile.transform.position.y, j), Quaternion.identity);
            }
        }

        //print("Tilewidth: " + tile.GetComponent<Renderer>().bounds.size);

    }
	
    void Update () {
		
	}
}
