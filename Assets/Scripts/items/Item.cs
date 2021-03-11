using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected PlayerStatusController psc; //THIS IS A QUICK ACCESS HANDLE FOR THE PLAYER STATUS CONTROLLER, since there should be only one

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Initialize();
    }

    protected void Initialize()
    {
        rb = GetComponent<Rigidbody2D>();
        psc = PlayerStatusController.psc;
    }

    protected void OnTriggerEnter2D(Collider2D cols)
    {
        if (cols.gameObject.layer == LayerMask.NameToLayer("player"))
            CollidePlayer(cols);
        if (cols.gameObject.layer == LayerMask.NameToLayer("npc"))
            CollideNPC(cols);
    }

    protected abstract void CollidePlayer(Collider2D cols);

    protected abstract void CollideNPC(Collider2D cols);

    protected void Disintegrate()
    {
        //TODO PLAY ANIM PICKUP
        Destroy(gameObject);
    }

}