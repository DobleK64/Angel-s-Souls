using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlip : MonoBehaviour
{
    public float speed;
    private SpriteRenderer _rend;
    public Transform personaje;
   


    void Start()
    {
        _rend = GetComponent<SpriteRenderer>();
        personaje = FindAnyObjectByType<PlayerMovement>().transform;
        
    }

    void Update()
    {
        // Verificar si el personaje colisiona con el enemigo
        if (personaje != null)
        {
            if (transform.position.x < personaje.position.x) //El enemigo sigue a nuestro personaje si se posiciona a la derecha
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                _rend.flipX = false;
                
            }
            else if (transform.position.x > personaje.position.x)  //El enemigo sigue a nuestro personaje si se posiciona a la izquierda
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                _rend.flipX = true;

            }
        }
    }


}

