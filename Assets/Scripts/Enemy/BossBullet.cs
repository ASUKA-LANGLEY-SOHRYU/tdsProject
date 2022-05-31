using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    private Transform player;
    public float speed = 10;
    public int damadge = 6;

    public GameObject hitEffect;

    private readonly string[] ignoreList = new string[] { "Boss", "BossBullet" , "InfoManager" };

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
        if (ignoreList.Any(x => collision.CompareTag(x)))
            return;
        if (collision.gameObject.CompareTag("Player"))
            player.GetComponent<PlayerHealth>().TakeDamage(damadge);
        if (hitEffect != null)
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
