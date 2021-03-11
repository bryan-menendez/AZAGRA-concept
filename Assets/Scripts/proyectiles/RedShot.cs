using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedShot : Projectile
{
    //make the bullet only collide with the player
    protected override void OnTriggerEnter2D(Collider2D cols)
    {
        CollidePlayer(cols);
    }
}
