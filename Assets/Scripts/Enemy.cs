using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    private GameObject attackArea = default;
    public LayerMask playerMask;
    private bool attacking = false;
    public Transform visionController;
    public float timeToAttack ;
    private float timer = 0f;
    public float lineDistance;
    public bool playerOnDetection; 

    [SerializeField] public float speed;
    [SerializeField] private Transform floorController;
    [SerializeField] private float distance;
    [SerializeField] private bool rightMove;
    private Rigidbody2D rb;
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        attackArea = transform.GetChild(0).gameObject; 
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerOnDetection)
        {
            target = Physics2D.Raycast(visionController.position, transform.right, lineDistance, playerMask).collider.gameObject;
            playerOnDetection = true;
        }
        Attack();
        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }

        }
    }

    private void FixedUpdate()
    {
        if (!playerOnDetection)
        {
            RaycastHit2D floorInformation = Physics2D.Raycast(floorController.position, Vector2.down, distance);
            rb.velocity = new Vector2(speed, rb.velocity.y);

            if (floorInformation == false)
            {
                Girar();
            }
        }
        else
        {
            Vector2 resta = (transform.position - target.transform.position).normalized;
            rb.velocity = speed * resta;
            // transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed);
        }
    }

    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }

    private void Girar()
    {
        rightMove = !rightMove;
        transform.eulerAngles = new Vector3(0,transform.eulerAngles.x + 180 ,0);
        speed *= -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(floorController.transform.position, floorController.transform.position + Vector3.down * distance);
        Gizmos.color = Color.yellow; 
        Gizmos.DrawLine(visionController.position, visionController.position + transform.right * lineDistance);
    }
}   