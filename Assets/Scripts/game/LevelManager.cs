using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //TODO; CLEAN THIS MESS
    public static GameObject player;
    public static GameObject currCheckpoint;

    public GameObject playerHandle;
    public GameObject checkpointHandle;

    void Start()
    {
        player = playerHandle;
        currCheckpoint = checkpointHandle;
    }
    

    public static void GameOver()
    {
        //TODO
        //trigger scenic death
        //give UI for the player to either respawn or restart

        RestartFromCheckpoint();

        //restart elements
        //setup player
        //setup all values to whatever they need to be
    }

    public static void RestartLevel()
    {

    }

    public static void RestartFromCheckpoint()
    {
        PlayerStatusController statusHandle = player.GetComponentInChildren<PlayerStatusController>();
        statusHandle.currHealth = statusHandle.maxHealth; //TODO, SAVE PREVIOUS HEALTH HERE 

        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        player.transform.position = currCheckpoint.transform.position;
    }

}
