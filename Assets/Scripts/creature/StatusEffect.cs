using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusEffect : MonoBehaviour
{
    //controller on which this object is attached
    public StatusController controller;

    //values
    readonly public float duration;
    public float tickEvery;
    public string type;
    
    //counters
    public float counter = 0;
    public float delta = 0;

    void Update()
    {
        TickCounter();
    }
    
    //tick down counter on step
    public void TickCounter()
    {
        if (delta < tickEvery)
            delta += Time.deltaTime;
        else
        {
            delta = 0; //reset the counter handle
            counter += tickEvery; //add the current tick to the pile
            ApplyStatus();
        }
        
        if (counter >= duration)
            Destroy(this);
    }

    //tick counter on zero
    public void TickImmediateCounter()
    {
        if (delta < counter)
            delta += Time.deltaTime;
        else
        {
            counter += tickEvery; //add the current tick to the pile
            ApplyStatus();
        }

        if (counter >= duration)
            Destroy(this);
    }

    //tick counter on zero, reset handle to zero, so every step takes longer
    //the increment is linear, ex 0.25, then 0.5, then 0.7, then 1, then self destruct
    public void TickFlatIncrementingCounter()
    {
        if (delta < counter) 
            delta += Time.deltaTime;
        else
        {
            delta = 0; //reset the counter handle
            counter += tickEvery; //add the current tick to the pile
            ApplyStatus();
        }

        if (counter >= duration)
            Destroy(this);
    }

    //Takes a controller and applies the effect
    public abstract void ApplyStatus();
}
