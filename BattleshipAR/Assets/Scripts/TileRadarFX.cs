using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Author: Konstantin Regenhardt*/
public class TileRadarFX : MonoBehaviour {

    [HideInInspector]
    public bool hit;
    [HideInInspector]
    public bool miss;

    private bool phase2;
    private GameObject gameController;
    private GameController gameControllerScript;

    private bool fired;
    private bool atHigh;

    private TileRadarController radarController;

    private Material current;
    private Color original;

    public Color hitColor;
    public Color missColor;
    public Color attackHoverHighlight;
    public Color attackHighlight;

    // Use this for initialization
    void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        gameControllerScript = gameController.GetComponent<GameController>();

        radarController = GetComponent<TileRadarController>();

        current = GetComponent<Renderer>().material;
        original = current.color;

        atHigh = false;
        fired = false;
        hit = false;
        miss = false;
	}
	
	// Update is called once per frame
	void Update () {
        phase2 = gameControllerScript.phase2;
        if (radarController.hasShipBlock && !radarController.shipBlockDestroyed && !atHigh)
        {
            //current.color = new Color(0.3f, 0.3f, 0); //Shows enemy ships only for demonstration purposes.
        }
        if (radarController.shipBlockDestroyed && !hit)
        {
            current.color = hitColor;
            hit = true;
            //gameControllerScript.aiActiveShipBlocks--;
        }
    }

    private void OnMouseEnter()
    {
        if (phase2 && gameControllerScript.playerTurn)
        {
            if (!fired)
            {
                atHigh = true;
                current.color = attackHoverHighlight;
            }
        }
    }

    private void OnMouseExit()
    {
        if (phase2 && gameControllerScript.playerTurn)
        {
            if (!fired)
            {
                atHigh = false;
                current.color = original;
            }
        }
    }

    private void OnMouseDown()
    {
        if (phase2 && gameControllerScript.playerTurn)
        {
            if (!fired)
            {
                current.color = attackHighlight;
            }
        }
    }

    private void OnMouseUp()
    {
        if (phase2 && gameControllerScript.playerTurn && !miss)
        {
            if (!fired)
            {
                fired = true;
                if (!radarController.shipBlockDestroyed)
                {
                    current.color = missColor;
                    miss = true;
                }
            }
        }
    }
}
