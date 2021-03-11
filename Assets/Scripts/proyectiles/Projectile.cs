using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 3f;

    public string type = "neutral";
    public float damage = 10f;
    public float stunTime = 0.3f;
    public float iframes = 0.7f;

    public Vector2 direction = Vector2.right; 
    
    protected Rigidbody2D rb;
    protected PlayerStatusController psc; //THIS IS A QUICK ACCESS HANDLE FOR THE PLAYER STATUS CONTROLLER, since there should be only one

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    protected void Update()
    {
        MoveHorizontal();
        TickCounters();

        if (lifetime <= 0)
            Disintegrate();
    }

    protected void Initialize()
    {
        rb = GetComponent<Rigidbody2D>();
        psc = PlayerStatusController.psc;
    }

    protected virtual void OnTriggerEnter2D(Collider2D cols)
    {
            CollideWalls(cols);
            CollidePlayer(cols);
            CollideNPC(cols);
    }

    protected void CollidePlayer(Collider2D cols)
    {
        if (cols.gameObject.layer == LayerMask.NameToLayer("player"))
        {
            if (psc.iframes <= 0)
            {
                psc.RecieveDamage(new DamageSource(type, damage));
                psc.RecieveStun(stunTime);
                psc.RecieveIframes(iframes);
                
                Disintegrate();
            }
        }
    }

    protected void CollideWalls(Collider2D cols)
    {
        if (cols.gameObject.layer == LayerMask.NameToLayer("collider"))
        {
            speed = 0f;
            lifetime = 0.3f; //TODO, CHANGE THIS BACK TO DISINTEGRATE(), this is just some cheap graphic effect
        }
    }

    protected void CollideNPC(Collider2D cols)
    {
        if (cols.gameObject.layer == LayerMask.NameToLayer("npc"))
        {
            StatusController npc = cols.transform.parent.GetComponentInChildren<StatusController>();
            
            if (npc.iframes <= 0)
            {
                psc.RecieveDamage(new DamageSource("neutral", damage));
                psc.RecieveStun(stunTime); //TODO MAKE A METHOD FOR THIS
                psc.RecieveIframes(iframes);

                Disintegrate();
            }
        }
    }

    protected void TickCounters()
    {
        lifetime -= Time.deltaTime;
    }

    protected void MoveHorizontal()
    {
        rb.velocity = direction * new Vector2 (speed, 0);
    }

    protected void Disintegrate()
    {
        //TODO PLAY ANIM EXPLOSION
        Destroy(gameObject);
    }
}
