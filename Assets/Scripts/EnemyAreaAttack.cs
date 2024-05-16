using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAreaAttack : MonoBehaviour
{
    public int damage;
    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
        }
    }
}
