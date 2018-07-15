using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {

    private GameObject playerRadar;
    private bool phase2;

    private GameObject gameController;
    private GameController gameControllerScript;

    // Use this for initialization
    void Start () {
        playerRadar = GameObject.FindGameObjectWithTag("PlayerRadar");

        gameController = GameObject.FindGameObjectWithTag("GameController");
        gameControllerScript = gameController.GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void Update () {
        phase2 = gameControllerScript.phase2;
	}
}
