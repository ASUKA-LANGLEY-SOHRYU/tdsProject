using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform bar;
    private PlayerHealth player;
    private int startHealth;
    void Start()
    {
        bar = transform.Find("Bar");
        player = DataManager.player.GetComponent<PlayerHealth>();
        startHealth = player.health;
    }

    // Update is called once per frame
    public void SetSize(float health)
    {
        bar.localScale = new Vector3(health / startHealth, 1f);
    }
}
