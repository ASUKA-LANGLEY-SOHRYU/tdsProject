using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;

    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    public int ammo = 20;
    public int maxAmmo = 20;
    public bool isReloading;
    public TMP_Text ammoInfo;

    public float timeBetweenShooting = 0.2f;
    private bool canShoot = true;

    public AudioSource shootSound;
    public AudioSource reloadSound;
    void Update()
    {   if (Input.GetKey(KeyCode.R) && ammo != maxAmmo)
            StartCoroutine(Reload());
        if (Input.GetButton("Fire1") && canShoot && !isReloading)
        {
            Shoot();
            shootSound.Play();
            if (ammo <= 0)
            {
                StartCoroutine(Reload());
            }
            else
                StartCoroutine(WaitForShooting(timeBetweenShooting));
        }
    }

    private IEnumerator WaitForShooting(float sec)
    {
        canShoot = false;
        yield return new WaitForSeconds(sec);
        canShoot = true;
    }

    private IEnumerator Reload()
    {
        isReloading = true;
        reloadSound.Play();
        yield return new WaitForSeconds(4.2f);
        isReloading = false;
        ammo = maxAmmo;
        UpdateInfoAboutAmmo();
    }

    void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        var rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        ammo -= 1;
        UpdateInfoAboutAmmo();
    }

    private void UpdateInfoAboutAmmo()
    {
        ammoInfo.text = string.Format("Ammo: {0}/{1}", ammo, maxAmmo);
    }
}
