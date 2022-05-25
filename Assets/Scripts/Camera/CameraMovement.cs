using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform player;
    public float dampTime = 0.4f;
    private Vector3 cameraPos;
    private Vector3 velocity = Vector3.zero;
    void Start()
    {
        player = DataManager.player;
    }

    // Update is called once per frame
    void Update()
    {
        cameraPos = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, cameraPos, ref velocity, dampTime);
    }
}
