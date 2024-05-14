using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private float enemyCurrentTime;
    private SpriteRenderer spriteRenderer;
    public float enemyCooldown;
    public Character  enemy;
    public EnemyType enemyType;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        switch(enemyType)
        {
            case EnemyType.CERBERUS:
                enemy = new Cerberus();
                break;
            case EnemyType.MAGIC_SKELETON:
                enemy = new MagicSkeleton();
                break;
            case EnemyType.NORMAL_SKELETON:
                enemy = new NormalSkeleton();
                break;
        }
        spriteRenderer.sprite = enemy.GetSprite();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (enemy.health <= 0)
        {
            Destroy(gameObject); 
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerMovement>()) 
        {
            if (enemyCurrentTime > enemyCooldown)
            {

                float dmg = enemy.Attack();
                GameManager.instance.character.health -= dmg;
                print("Vida player: " + GameManager.instance.character.health);
                enemyCurrentTime = 0; 

            }
        }
    }
}
