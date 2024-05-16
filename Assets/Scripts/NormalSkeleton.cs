using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSkeleton : Character
{
    public NormalSkeleton() : base("NormalSkeleton", 5 , 75, Resources.Load<Sprite>("Sprites/normalskeleton"))
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
