using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Author: Konstantin Regenhardt*/
public class TileRadarController : MonoBehaviour {
    
    [HideInInspector]
    public bool hasShipBlock;
    [HideInInspector]
    public bool shipBlockDestroyed;

    [HideInInspector]
    public bool hit;
    [HideInInspector]
    public bool miss;

    private GameController gameControllerScript;
    private TileRadarFX tileRadarFXScript;

    // Use this for initialization
    void Start () {
        hasShipBlock = false;
        shipBlockDestroyed = false;
        gameControllerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        tileRadarFXScript = GetComponent<TileRadarFX>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnMouseUp()
    {
        if (gameControllerScript.phase2 && gameControllerScript.playerTurn /*&& !tileRadarFXScript.miss && !tileRadarFXScript.hit*/ )
        {
            if (hasShipBlock && gameControllerScript.playerTurn && !shipBlockDestroyed)
            {
                shipBlockDestroyed = true;
                gameControllerScript.aiActiveShipBlocks--;
            }
            gameControllerScript.playerTurn = false;
            gameControllerScript.aiTurn = true;
        }
    }
}
