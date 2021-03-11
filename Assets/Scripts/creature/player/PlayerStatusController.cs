using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusController : StatusController
{
    public static PlayerStatusController psc;
    
    // Start is called before the first frame update
    void Start()
    {
        iframes = 2;
        isStunned = false;
        statusList = new ArrayList(); //TODO: STORE THE PREVIOUS LIST IN CASE OF A SHORT TRANSITION
        psc = this;
    }

    
    public override void Die()
    {
        

        if (psc.currHealth < -100 )
        {
            LevelManager.GameOver();

        }
                    
        
    }
}
