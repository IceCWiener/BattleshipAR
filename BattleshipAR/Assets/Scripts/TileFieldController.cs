using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Author: Konstantin Regenhardt*/

public class TileFieldController : MonoBehaviour {

    [HideInInspector]
    public bool hasShipBlock;   //Accessed by AIController
    [HideInInspector]
    public bool shipBlockDestroyed; //Accessed by AIController
    [HideInInspector]
    public bool miss;   //Accessed by AIController


    // Use this for initialization
    void Start()
    {
        hasShipBlock = false;
        shipBlockDestroyed = false;
        miss = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
