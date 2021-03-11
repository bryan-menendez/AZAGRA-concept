using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorScript : MonoBehaviour
{
    public GameObject spriteHandle; 

    private Animator animator;
    private PhysicsController physics;
    private StatusController status;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        status = GetComponent<StatusController>();
        physics = GetComponent<PhysicsController>();
        rb = transform.parent.GetComponent<Rigidbody2D>();
        animator = spriteHandle.GetComponent<Animator>();
        sprite = spriteHandle.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Facing();
        InformAnimationController();
    }

    private void InformAnimationController()
    {
        animator.SetBool("isgrounded", physics.IsGrounded());
        animator.SetBool("isrunning", IsRunning());
        animator.SetFloat("vacceleration", rb.velocity.y);
    }

    private void Facing()
    {
        //moving right, facing left
        if(physics.hAxis > 0 && !status.isStunned)
            sprite.flipX = false;

        if(physics.hAxis < 0 && !status.isStunned)
            sprite.flipX = true;
    }

    private bool IsRunning()
    {
        // its grounded, its moving, its not stunned
        if (physics.IsGrounded() && physics.hAxis != 0 && !status.IsStunned())
        {
            return true;
        }

        return false;
    }
}
