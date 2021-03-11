using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    private BoxCollider2D box;
    
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D cols)
    {
        if (cols.gameObject.name.Equals("physics"))
        {
            if (cols.transform.parent.gameObject.name.Equals("player"))
            {
                LevelManager.RestartFromCheckpoint();
            }
        }
    }
}
