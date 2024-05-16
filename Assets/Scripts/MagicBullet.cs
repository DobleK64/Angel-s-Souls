using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBullet : MonoBehaviour
{
    public float speed; 
    public int damage;
    private float maxtime;
    private float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        maxtime = 2; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * speed * -Vector2.right);
        currentTime += Time.deltaTime; 
        if (currentTime >= maxtime)
        {
            currentTime = 0;
            Destroy(gameObject);
        }
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
