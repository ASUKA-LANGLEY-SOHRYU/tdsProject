using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 120;

    public GameObject deathScreen;

    public HealthBar healthBar;

    public GameObject cam;

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetSize(health);
        if (health <= 0)
            Die();
    }

    void Die()
    {
        Instantiate(deathScreen, new Vector3(cam.transform.position.x, cam.transform.position.y), Quaternion.identity);
        gameObject.GetComponent<PlayerMovement>().speed = 0f;
        Destroy(cam.GetComponent<CameraMovement>());
    }
}
