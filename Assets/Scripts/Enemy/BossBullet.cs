using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    private Transform player;
    public float speed = 10;
    public int damadge = 6;

    public GameObject hitEffect;

    void Start()
    {
        player = DataManager.player;
    }

    void Update()
    {
        RotateTowardsPlayer();
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private void RotateTowardsPlayer()
    {
        var offset = 90f;
        Vector2 direction = transform.position - player.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boss") || collision.gameObject.CompareTag("BossBullet"))
            return;
        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damadge);
        if (hitEffect != null)
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
