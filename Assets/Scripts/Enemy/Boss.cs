using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject bullet;

    void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            var rand = Random.Range(4, 10);
            yield return new WaitForSeconds(rand);
            for(var i = 0; i < 5; i++)
                Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }

    private void OnDestroy()
    {
        StopCoroutine(Shoot());
    }
}
