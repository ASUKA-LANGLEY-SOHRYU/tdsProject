using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 1000;

    public GameObject deathScreen;

    public HealthBar healthBarScript;

    public GameObject cam;

    public GameObject UI;

    public AudioSource damageSound;
    public GameObject enemies;

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBarScript.SetSize(health);
        if (health <= 0)
            Die();
        DataManager.playerHealth = health;
        damageSound.pitch = Random.Range(0.3f, 1.5f);
        damageSound.Play();
    }

    void Die()
    {
        UI.SetActive(false);
        gameObject.SetActive(false);
        enemies.SetActive(false);
        Instantiate(deathScreen, new Vector3(cam.transform.position.x, cam.transform.position.y), Quaternion.identity);
        gameObject.GetComponent<PlayerMovement>().speed = 0f;
        Destroy(cam.GetComponent<CameraMovement>());
    }
}
