using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBullet : Projectile
{
    new void Start()
    {
        Initialize();
        speed = 20f;
        damage = 20f;
    }

    new void OnTriggerEnter2D(Collider2D cols)
    {
        CollideWalls(cols);
    }



}
