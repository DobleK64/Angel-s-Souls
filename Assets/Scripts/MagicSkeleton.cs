using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSkeleton : Character
{
    public MagicSkeleton() : base("MagicSkeleton", 15 , 100, Resources.Load<Sprite>("Sprites/magicskeleton"))
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
