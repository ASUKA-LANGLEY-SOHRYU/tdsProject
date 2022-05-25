using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5f;
    Camera cam;
    private bool isSprint = false;
    private float sprintMultiplier = 2f;

    private Vector2 movement;
    private Vector2 mousePos;
    
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprint = !isSprint;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * movement * (isSprint ? sprintMultiplier : 1));

        var lookDir = mousePos - rb.position;
        var rotate = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = rotate;
    }
}
