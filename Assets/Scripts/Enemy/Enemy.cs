using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 120;

    public GameObject deathEffect;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Die();
    }

    void Die()
    {
        var effect = Instantiate(deathEffect, transform.position, gameObject.transform.rotation);
        Destroy(effect, 1f);
        Destroy(gameObject);
    }
}
