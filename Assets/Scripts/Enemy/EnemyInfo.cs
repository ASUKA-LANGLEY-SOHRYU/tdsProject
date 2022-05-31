using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class EnemyInfo : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject wormScreen;
    public GameObject trojanScreen;

    public Transform camera;
    private GameObject canvas;

    private GameObject screen;

    private readonly Dictionary<string, GameObject> screens = new Dictionary<string, GameObject>();

    private void Start()
    {
        canvas = camera.gameObject.GetComponentInChildren<Canvas>().gameObject;
        screens["Worm"] = wormScreen;
        screens["Trojan"] = trojanScreen;
        if(SceneManager.GetActiveScene().buildIndex == 1)
            screen = Instantiate(startScreen, new Vector3(camera.position.x, camera.position.y), Quaternion.identity, camera);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            Destroy(screen);
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        var enemy = col.gameObject.GetComponent<Enemy>();
        if (enemy == null)
            return;
        if (screens.ContainsKey(enemy.tag) && DataManager.enemyTags.All(x => !enemy.CompareTag(x)))
        {
            if (screen != null)
                Destroy(screen);
            screen = Instantiate(screens[enemy.tag], new Vector3(camera.position.x, camera.position.y), Quaternion.identity, camera);
            DataManager.enemyTags.Add(enemy.tag);
        }
    }
}
