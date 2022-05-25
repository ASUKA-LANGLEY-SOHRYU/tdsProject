using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject hitEffect;
    public int damage;

    void OnCollisionEnter2D(Collision2D collision)
    {
        var effect =Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);
        PlayerHealth ph = collision.gameObject.GetComponent<PlayerHealth>();
        if (ph)
            ph.TakeDamage(damage);
        Destroy(gameObject);
    }
}
