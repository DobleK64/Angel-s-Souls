using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] public float health = 200;

    private float MAX_HEALTH = 200;
    [SerializeField] private LifeBar lifeBar;
    public AudioClip damageClip ; 

    private void Start()
    {
         MAX_HEALTH = health;
         lifeBar.StartLifeBar(health/MAX_HEALTH);
         health = Mathf.Clamp(health, 0, 200);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            // Damage(10);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            // Heal(10);
        }
    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }

        this.health -= amount;
        lifeBar.ChangeActualLife(health/MAX_HEALTH);
        AudioManager.instance.PlayAudio(damageClip, "damageSound");
        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
        }

        bool wouldBeOverMaxHealth = health + amount > MAX_HEALTH;

        if (wouldBeOverMaxHealth)
        {
            this.health = MAX_HEALTH;
        }
        else
        {
            this.health += amount;
        }
    }

    private void Die()
    {
        
        Debug.Log("I am Dead!");
        Destroy(gameObject);

         
    }
}
