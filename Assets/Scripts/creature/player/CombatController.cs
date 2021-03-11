using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    public GameObject spriteHandle;
    public GameObject shootSourceLeft;
    public GameObject shootSourceRight;
    public GameObject shotPrefab;

    public float shootCooldown = 0.25f;
    public float shootTime = 0; 

    private SpriteRenderer sprite;


    public void Start()
    {
        sprite = spriteHandle.GetComponent<SpriteRenderer>();
    }

    public void Shoot()
    {
        GameObject shot = Instantiate(shotPrefab);
        Projectile p = shot.GetComponent<Projectile>();
        
        //looking left, shoot left
        if (sprite.flipX)
        {
            p.direction = Vector2.left;
            shot.transform.position = shootSourceLeft.transform.position;
        }
            
        else
        {
            shot.transform.position = shootSourceRight.transform.position;
            p.direction = Vector2.right;
        }
            

    }
}
