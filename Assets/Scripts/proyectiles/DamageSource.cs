using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSource
{
    public string type;
    private float damage;
    //public List<float> values; //index 0 is base damage, the rest are meant for upcoming features

    public DamageSource()
    {
        //this.values = new List<float>();
    }

    public DamageSource (string type, float damage)
    {
        this.type = type;
        this.damage = damage;
        //this.values = new List<float>();
        //values.Add(value);
    }

    public float Damage { get => damage; set => damage = value; }
}
