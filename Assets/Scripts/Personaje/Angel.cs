using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angel : Character
{
    public Angel() : base("Azrael", Random.Range(20, 30), 200, Resources.Load<Sprite>("Sprites/Angel"))
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
