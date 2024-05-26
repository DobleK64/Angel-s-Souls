using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestaureHealth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            //health += 10; 
        }
    }
}
