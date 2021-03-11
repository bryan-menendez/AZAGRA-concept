using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    public GameObject physicsHandle;

    public float runSpeedBase = 10f;
    public float runSpeed;
    public float jumpPower = 10f;

    public float vDeceleration = 1f;

    public bool isGrounded;
    public bool debugGroundRay = false;
    public float groundrayOffsetX = -0.45f;
    public float groundrayOffsetY = -1.32f;
    
    public bool isFacingWall = false;
    public bool debugFaceRay = false;
    public float faceRaySize = 1.81f;
    public float facerayOffsetX = -0.47f;
    public float facerayOffsetY = 0.55f;


    private Rigidbody2D rb;
    private BoxCollider2D box;

    public float hAxis;
    public float vAxis;

    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        box = physicsHandle.GetComponent<BoxCollider2D>();
        isGrounded = true;
    }

    void Update()
    {
        ParseInput();
        SetupSpeed();
        CheckFallDamage();
        CheckGrounded();
        CheckFacingWall();
        ApplyAirDeceleration();
    }

    public void ParseInput()
    {
        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");

        if (hAxis > 0.7f)
            hAxis = 1f;
        if (hAxis < -0.7f)
            hAxis = -1f;
    }

    public void SetupSpeed()
    {
        runSpeed = runSpeedBase;
    }

    public void MoveHorizontal()
    {
        if (!isFacingWall)
            rb.velocity = new Vector2(runSpeed * hAxis, rb.velocity.y);
    }

    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpPower);
    }

    private void CheckFacingWall()
    {
        float raySize = faceRaySize;
        float handleOffset;

        //Facing Right
        if (hAxis > 0)
            handleOffset = -facerayOffsetX;
        else if (hAxis < 0)  //facing left
            handleOffset = facerayOffsetX;
        else
            handleOffset = 0;

        if (debugFaceRay)
        {
            Vector3 start = new Vector3(rb.position.x + handleOffset, rb.position.y + facerayOffsetY, 0);
            Vector3 dir = new Vector3(0, -raySize, 0);
            Debug.DrawRay(start, dir, Color.green, 0, false);
            //Debug.DrawRay(start, dir - new Vector3(0,0.1f,0), Color.red, 0, false);
        }

        //TODO
        //TWO JUDGE SYSTEM

        Vector2 rayStart = new Vector2(rb.position.x + handleOffset, rb.position.y + facerayOffsetY);
        isFacingWall = Physics2D.Raycast(rayStart, Vector2.down, raySize, 1 << 8);
    }

    void CheckFallDamage()
    {
        //TODO
    }

    /**
    * Draws a ray at the feet of the players collider to check if there is ground there
    * returns true if it collides with a collider (in the colliders layer)
    */
    void CheckGrounded()
    {
        if (debugGroundRay)
        {
            Vector3 start = new Vector3(rb.position.x + groundrayOffsetX, rb.position.y + groundrayOffsetY, 0);
            Vector3 dir = new Vector3(box.size.x * box.transform.localScale.x, 0, 0);
            Debug.DrawRay(start, dir, Color.green, 0, false);
        }
        Vector2 ray1start = new Vector2(rb.position.x + groundrayOffsetX, rb.position.y + groundrayOffsetY);
        Vector2 ray1dir = new Vector3(box.size.x * box.transform.localScale.x, 0);

        bool hit = Physics2D.Raycast(ray1start, ray1dir, box.size.x * box.transform.localScale.x, 1 << 8);
        
        isGrounded = hit;
    }

    void ApplyAirDeceleration()
    {
        if (!Input.GetButton("Jump") && rb.velocity.y > 0)
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y-vDeceleration);
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }
}
