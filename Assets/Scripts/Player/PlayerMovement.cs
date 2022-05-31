using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5f;
    Camera camera;
    private bool isSprint = false;
    private float sprintMultiplier = 2f;
    public float fatigue = 100;
    public float maxFatigue = 100;
    public FatigueScript fatigueScript;
    private bool canRun = true;

    private Vector2 movement;
    private Vector2 mousePos;

    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        if (canRun && Input.GetKey(KeyCode.LeftShift) && fatigue > 1)
        {
            isSprint = true;
            fatigue -= 0.3f;
            if (fatigue < 3)
            {
                canRun = false;
                StartCoroutine(TiredForSeconds(1));
            }
        }
        else if (fatigue <= maxFatigue)
        {
            isSprint = false;
            if (movement == Vector2.zero)
                fatigue += 0.3f;
            else
                fatigue += 0.15f;
        }
        if (fatigue != maxFatigue)
            fatigueScript.SetSize(fatigue);

        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * movement * (isSprint ? sprintMultiplier : 1));

        var lookDir = mousePos - rb.position;
        var rotate = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = rotate;
    }

    private IEnumerator TiredForSeconds(float sec)
    {
        yield return new WaitForSeconds(sec);
        canRun = true;
    }
}
