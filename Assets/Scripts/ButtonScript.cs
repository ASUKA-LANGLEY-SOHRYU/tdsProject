using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject door;
    public Sprite pressedButton;
    public GameObject buttonInfo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;
        var sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = pressedButton;
        sr.color = new Color(0.01f, 1f, 1f);
        Destroy(door);
    }
}
