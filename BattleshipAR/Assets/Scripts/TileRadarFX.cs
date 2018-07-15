using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRadarFX : MonoBehaviour {

    private bool phase2;
    private GameObject gameController;
    private GameController gameControllerScript;
    private bool fired;

    private Material current;
    private Color original;

    public Color hit;
    public Color miss;
    public Color attackHoverHighlight;
    public Color attackHighlight;

    // Use this for initialization
    void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        gameControllerScript = gameController.GetComponent<GameController>();
        current = GetComponent<Renderer>().material;
        original = current.color;
        fired = false;
	}
	
	// Update is called once per frame
	void Update () {
        phase2 = gameControllerScript.phase2;
	}

    private void OnMouseEnter()
    {
        if (phase2)
        {
            if (!fired)
            {
                current.color = attackHoverHighlight;
            }
        }
    }

    private void OnMouseExit()
    {
        if (phase2)
        {
            if (!fired)
            {
                current.color = original;
            }
        }
    }

    private void OnMouseDown()
    {
        if (phase2)
        {
            if (!fired)
            {
                current.color = attackHighlight;
            }
        }
    }

    private void OnMouseUp()
    {
        if (phase2)
        {
            if (!fired)
            {
                fired = true;
                current.color = miss;
            }
        }
    }
}
