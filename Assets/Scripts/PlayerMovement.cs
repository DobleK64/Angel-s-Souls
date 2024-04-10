﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public KeyCode rightKey, leftKey, jumpKey;
    public float speed, rayDistance, jumpForce;
    public LayerMask groundMask; // mascara de colisiones con la que queremos que choque el rayo.
    public AudioClip jumpClip; // 
    public int saltoDoble = 0; //
    private Rigidbody2D rb;
    private SpriteRenderer _rend;
    private Animator _animator;
    private Vector2 dir;
    private bool _intentionToJump;
    private Vector2 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _rend = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();

        originalPosition = transform.position;
        Camera.main.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        dir = Vector2.zero;
        if (Input.GetKey(rightKey))
        {
            _rend.flipX = false;
            dir = Vector2.right;
        }
        else if (Input.GetKey(leftKey))
        {
            _rend.flipX = true;
            dir = new Vector2(-1, 0);
        }

        if (Input.GetKeyDown(jumpKey))
        {
            _intentionToJump = true;
            Debug.Log(saltoDoble);
        }

        //ANIMACIONES.
        if (dir != Vector2.zero)
        {
            //estamos andando.
            _animator.SetBool("andar", true);
        }
        else
        {
            //estamos parados.
            _animator.SetBool("andar", false);
        }
    }

    private void FixedUpdate()
    {
        bool grnd = IsGrounded();
        //if (dir != Vector2.zero)
        {
            float currentYVel = rb.velocity.y; //sirve para que si te estas moviendo, caigas a la misma velocidad que te mueves.
            Vector2 nVel = dir * speed;
            nVel.y = currentYVel; //Quedarse la velocidad de Y.
            rb.velocity = nVel; //Mantener la velocidad en Y en las caidas despues del Salto.
        }

        if (_intentionToJump && (IsGrounded() || saltoDoble < 2)) //Salto del corazon.
        {

            _animator.Play("saltar");
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce * rb.gravityScale * rb.drag, ForceMode2D.Impulse); //rb.drag es para evitar que el corazon se deslice.
            AudioManager.instance.PlayAudio(jumpClip, "jumpSound", false, 0.1f);
            saltoDoble++;


        }
        _intentionToJump = false;
        _animator.SetBool("isGrounded", grnd);
    }
    private bool IsGrounded() //se lanza un rayo desde el corazon hacia abajo y detectar la m�scara de colisiones que hemos establecido (detectar el suelo).
    {
        RaycastHit2D collisions = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundMask);
        if (collisions)
        {
            saltoDoble = 0;
            return true;
        }
        return false;
    }
    private void OnDrawGizmos() //identificar al rayo.
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);
    }
    public void resetCorazon() // Para que nuestro corazon vuelva a su posicion incial al caer
    {
        GameManager.instance.LoadScene("GameOver");
    }
    void OnDestroy() // Esto comprueba que nuestro corazon a sido destruido
    {


        AudioManager.instance.ClearAudios(); //Esto nos ayuda a limpiar los audios una vez nuestro personaje es destruido
                                             // SceneManager.LoadScene("Juego"); // Si nuestro corazon a sido destruido se reiniciara la escena ("DESTRUIDO" caer al vacio solo hara que volvamos a la posiscion inicial)
    }

}


