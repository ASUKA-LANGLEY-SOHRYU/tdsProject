using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                Instantiate(bullet, 
                    transform.position + new Vector3(Random.Range(1, 30), Random.Range(1, 30), Random.Range(1, 30)),
                    Quaternion.identity);
        }
    }

    private void OnDestroy()
    {
        StopCoroutine(Shoot());
        SceneManager.LoadScene(0);
    }
}
