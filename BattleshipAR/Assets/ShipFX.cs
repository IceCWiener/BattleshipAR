using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Author: Konstantin Regenhardt*/
//This script enlarges the GameObject it is attached to and highlights (work in progress) it while the player clicks.

public class ShipFX : MonoBehaviour {

    public Material material;
    public Material highlight;
    public float scaleFactor;

    private Material current;
    private float scaleX;
    private float scaleY;
    private float scaleZ;

	// Use this for initialization
	void Start () {
        current = GetComponent<Renderer>().material;
        scaleX = GetComponent<Transform>().localScale.x;
        scaleY = GetComponent<Transform>().localScale.y;
        scaleZ = GetComponent<Transform>().localScale.z;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseOver()
    {
        GetComponent<Transform>().localScale = new Vector3(scaleX + scaleFactor, scaleY + scaleFactor, scaleZ + scaleFactor);
    }

    private void OnMouseExit()
    {
        GetComponent<Transform>().localScale = new Vector3(scaleX, scaleY, scaleZ);
    }

    private void OnMouseDown()
    {
        current = highlight;
        
    }

    private void OnMouseUp()
    {
        current = material;
        
    }
}
