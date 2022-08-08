using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public int ammo = 0;
    private int maxAmmo = 1;
    public float cooldown;

    private void OnEnable()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (ammo > 0)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            ammo -= 1;
        }
        Invoke("Reload", cooldown / 2);
    }

    private void Reload()
    {
        ammo = maxAmmo;
        Invoke("Shoot", cooldown / 2);
    }
}
