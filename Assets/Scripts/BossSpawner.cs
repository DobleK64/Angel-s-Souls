using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject Cerberus;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = Cerberus.GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>()) 
        {
            Instantiate(Cerberus, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
