using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement pm = collision.GetComponent<PlayerMovement>();
        if (pm)
        {
            pm.resetPersonaje(); 
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
