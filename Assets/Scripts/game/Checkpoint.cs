using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D cols)
    {
        //INTENDED TO COLLIDE ONLY WITH PLAYER LAYER
        //
        // if (cols.gameObject.name.Equals("physics"))
        // {
        //     if (cols.transform.parent.gameObject.name.Equals("player"))
        //     {
                LevelManager.currCheckpoint = gameObject;
        //     }
        // }
    }
}
