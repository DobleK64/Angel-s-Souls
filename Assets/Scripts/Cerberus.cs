using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cerberus : Character
{
    public Cerberus() : base("Cerberus", 25, 300, Resources.Load<Sprite>("Sprites/cerberus")) 
    {

    }

    public override float Attack()
    {
        return damage;

    }

    public override float Heal()
    {
        
        return health;
    }
}
