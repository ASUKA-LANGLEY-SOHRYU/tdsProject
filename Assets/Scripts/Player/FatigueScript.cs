using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatigueScript : MonoBehaviour
{
    private Transform bar;
    private PlayerMovement player;

    void Start()
    {
        bar = transform.Find("Bar");
        player = DataManager.player.GetComponent<PlayerMovement>();
    }

    public void SetSize(float fatigue)
    {
        bar.localScale = new Vector3(fatigue / player.maxFatigue, 1f);
    }
}
