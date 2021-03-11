using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecubotController : MonoBehaviour
{
    SecubotCombatController combat;

    // Start is called before the first frame update
    void Start()
    {
        combat = GetComponent<SecubotCombatController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (combat.shootTime <= 0)
        {
            combat.Shoot();
            combat.shootTime = combat.shootCooldown;
        }
        else
            combat.shootTime -= Time.deltaTime;
    }
}
