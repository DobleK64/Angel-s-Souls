using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBullet : MonoBehaviour
{
    public float speed; 
    public int damage; 
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * speed * Vector2.right);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health))
        {
            health.Damage(damage);
            Destroy(gameObject);
        }
    }
}
