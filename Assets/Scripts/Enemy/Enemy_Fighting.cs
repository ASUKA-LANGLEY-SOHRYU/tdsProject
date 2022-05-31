using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy_Fighting : MonoBehaviour
{
    public float speed;
    public int damage = 1;
    public float lookingDistance;
    private float startSpeed;

    private Transform player;
    private Rigidbody2D rb;
    private bool isCollidesPlayer = false;
    void Start()
    {
        player = DataManager.player;
        startSpeed = speed;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        var distance = Vector2.Distance(transform.position, player.position);
        var rayHits = Physics2D.LinecastAll(transform.position, player.position);
        if (distance <= lookingDistance && !IsWallInTheWay(rayHits))
        { 
            var direction = player.GetComponent<Rigidbody2D>().position - rb.position;
            rb.MovePosition(rb.position + direction.normalized * Time.fixedDeltaTime * speed);
            RotateTowardsTarget();
        }
    }

    bool IsWallInTheWay(RaycastHit2D[] rayHits)
    {
        return rayHits.Any(x => x.collider.CompareTag("Wall"));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;
        var ph = collision.gameObject.GetComponent<PlayerHealth>();
        isCollidesPlayer = true;
        StartCoroutine(DealDamage(ph));
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;
        isCollidesPlayer = false;
    }

    private IEnumerator DealDamage(PlayerHealth ph)
    {
        while (true)
        {
            if (!isCollidesPlayer)
                yield break;
            ph.TakeDamage(damage);
            speed = 0;
            yield return new WaitForSeconds(.1f);
            speed = startSpeed;
            yield return new WaitForSeconds(1f);
        }
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
