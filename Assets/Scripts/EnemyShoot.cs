using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform shootController;
    public float lineDistance;
    public LayerMask playerMask;
    public bool playerOnRange;
    public GameObject bullet;
    public float shootCooldown;
    public float shootTime;
    public float shootTimeWaiting;
    // Update is called once per frame
    void Update()
    {
        playerOnRange = Physics2D.Raycast(shootController.position, transform.right , lineDistance, playerMask); 
       if (playerOnRange )
        {
            if(Time.time > shootCooldown + shootTime)
            {
                shootTime = Time.time;
                Invoke(nameof(Shoot),shootTimeWaiting);
            }
        }
    }
    private void Shoot()
    {
        Instantiate(bullet, shootController.position, shootController.rotation);
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(shootController.position, shootController.position + transform.right * lineDistance);
    }
}
