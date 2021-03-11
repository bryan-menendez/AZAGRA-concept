using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private StatusController status;
    private PhysicsController physics;
    private CombatController combat;

    private bool paused;
    private bool stunned;

    // Start is called before the first frame update
    void Start()
    {
        physics = GetComponent<PhysicsController>();
        status = GetComponent<StatusController>();
        combat = GetComponent<CombatController>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckFlags();

        if (!paused)
        {
            ParseInput();
            ListenInput();  
        }
    }

    void CheckFlags()
    {
        paused = GameManager.isPaused();
        stunned = status.isStunned;
    }

    private void ParseInput()
    {
        physics.ParseInput();
    }

    /*
    *   CONTROLLER BEHAVIOUR MAPPING
    */

    void ListenInput()
    {
        if (!paused)
        {
            if (!stunned)
            {
                physics.MoveHorizontal();

                if (Input.GetButtonDown("Jump"))
                {
                    if(physics.IsGrounded())
                        physics.Jump();
                }

                if (Input.GetButtonDown("Shoot"))
                {
                    combat.Shoot();
                }
                    
            }
        }
        
    }
}
