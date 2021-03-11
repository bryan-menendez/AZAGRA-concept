using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusController : MonoBehaviour
{
    public float currHealth;
    public float maxHealth;

    public bool isStunned;
    public float stunTime;
    public float iframes;
    
    public ArrayList statusList;

    void Start()
    {
        iframes = 0;
        isStunned = false;
        statusList = new ArrayList();
    }

    void Update()
    {
        //cant have more than max health
        if (currHealth > maxHealth)
            currHealth = maxHealth;

        //below -100 equals death
        if (currHealth < 0)
            Die();        

        if (iframes > 0)
            iframes -= Time.deltaTime;
        
        if (stunTime > 0)
        {
            isStunned = true;
            stunTime -= Time.deltaTime;
        }

        if (stunTime <= 0)
            isStunned  = false;
    }

    public bool IsStunned()
    {
        return isStunned;
    }

    public void RecieveDamage(DamageSource damagesource)
    {
        //could be adaptive being lowered when hp is low
        currHealth -= damagesource.Damage;
    }

    public void RecieveDamage(float amount)
    {
        currHealth -= amount;
    }

    public void RecieveStun(float amountOfTime)
    {
        //could use diminishing returns
        stunTime += amountOfTime;
    }

    public void RecieveIframes(float amountOfTime)
    {
        //maybe have bonuses against bosses?
        iframes += amountOfTime;
    }

    public void RecieveHealth (float amountOfHealth)
    {
        if (currHealth + amountOfHealth >= maxHealth)
            currHealth = maxHealth;
        else
            currHealth += amountOfHealth;
    }

    public void RecieveMaxHealth (float amountOfExtraHealth)
    {
        maxHealth += amountOfExtraHealth;
    }

    public virtual void Die(){
        //TODO: generic npc death
    }
}
