using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] spawnPoint;
    
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            var rand = Random.Range(0, enemies.Length);
            var randPosition = Random.Range(0, spawnPoint.Length); //TODO: ��������� ����� ����������� ���� �� ���� ������.
            try
            {
                Instantiate(enemies[rand], spawnPoint[randPosition].transform.position, Quaternion.identity);
            }
            catch { }
            yield return new WaitForSeconds(3f);
        }
    }
}
