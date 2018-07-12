using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Author: Konstantin Regenhardt*/
//This script enlarges the GameObject it is attached to and highlights (work in progress) it while the player clicks.

public class TileFX : MonoBehaviour
{

    //public Material material;
    //public Material highlight;
    public float scaleFactor;

    [Range(0, 10)]
    public float colorIntensity;

    private Material current;
    private Color original;
    private float scaleX;
    private float scaleY;
    private float scaleZ;

    // Use this for initialization
    void Start()
    {
        current = GetComponent<Renderer>().material;
        original = current.color;
        scaleX = GetComponent<Transform>().localScale.x;
        scaleY = GetComponent<Transform>().localScale.y;
        scaleZ = GetComponent<Transform>().localScale.z;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        GetComponent<Transform>().localScale = new Vector3(scaleX + scaleFactor, scaleY + scaleFactor, scaleZ + scaleFactor);
        current.color = original + new Color(colorIntensity, colorIntensity, colorIntensity);
    }

    private void OnMouseExit()
    {
        GetComponent<Transform>().localScale = new Vector3(scaleX, scaleY, scaleZ);
        current.color = original;
    }

    private void OnMouseDown()
    {
        //current = highlight;

    }

    private void OnMouseUp()
    {
        //current = material;

    }
}
