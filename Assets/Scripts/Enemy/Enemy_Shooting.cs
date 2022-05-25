using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shooting : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float lookingDistance;
    
    public Transform firePoint;

    private float timeBtwShots;
    public float startTimeBtwShots = 1f;

    private Transform player;
    private Rigidbody2D rb;
    
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    void Start()
    {
        player = DataManager.player;
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        var dist = Vector2.Distance(transform.position, player.position);
        var direction = player.GetComponent<Rigidbody2D>().position - rb.position;
        if (dist <= lookingDistance)
        {
            rb.MovePosition(rb.position + direction.normalized * speed * Time.deltaTime);
            RotateTowardsTarget();
            
            if (timeBtwShots <= 0)
            {
                Shoot();
                timeBtwShots = startTimeBtwShots;
            }
            else
                timeBtwShots -= Time.deltaTime;
        }
    }
    
    void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        var rb = bullet.GetComponent<Rigidbody2D>();
        
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
    
    private void RotateTowardsTarget()
    {
        var offset = 90f;
        Vector2 direction = transform.position - player.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;       
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }
}
