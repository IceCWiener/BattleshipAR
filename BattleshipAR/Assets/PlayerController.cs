using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Author: Konstantin Regenhardt*/

public class PlayerController : MonoBehaviour {

    GameObject player;
    private float boardSizeX;
    private float boardSizeY;
    private float tileSize;

    public Transform tile;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        boardSizeX = player.GetComponent<Transform>().transform.localScale.x;
        boardSizeY = player.GetComponent<Transform>().transform.localScale.z;

        for(int i = 0; i < boardSizeX; i++)
        {
            for(int j = 0; i < boardSizeY; j++)
            {
                Instantiate(tile, new Vector3(i, j, tile.transform.position.z), Quaternion.identity);
            }
        }
    }
	
    void Update () {
		
	}
}
