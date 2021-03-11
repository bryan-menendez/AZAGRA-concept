using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static bool paused;

    void Start()
    {
        paused = false;
    }

    void Update()
    {
        
    }

    public void TogglePause()
    {
        //TODO

        if (paused)
            paused = false;
        else
            paused = true;
    }

    public static bool isPaused()
    {
        return paused;
    }
}
