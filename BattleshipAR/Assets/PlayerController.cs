using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Author: Konstantin Regenhardt*/

public class PlayerController : MonoBehaviour {

    private float boardSizeX;
    private float boardSizeZ;
    private float tileSize;

    public GameObject player;
    public Transform tile;

	void Start () {
        boardSizeX = player.GetComponent<Transform>().transform.localScale.x;
        boardSizeZ = player.GetComponent<Transform>().transform.localScale.z;
        //print("BoardX: " + boardSizeX);
        //print("BoardZ: " + boardSizeZ);

        for(float i = -2; i <= 2; i++)
        {
            for(float j = -2; i <= 2; j++)
            {
                Instantiate(tile, new Vector3(i, j, tile.transform.position.z), Quaternion.identity);
            }
        }

    }
	
    void Update () {
		
	}
}
