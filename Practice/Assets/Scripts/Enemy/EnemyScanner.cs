using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScanner : MonoBehaviour
{
    public bool inView;
    public GameObject gun;
    private EnemyShoot enemyShoot;

    private void Awake()
    {
        enemyShoot = gun.GetComponent<EnemyShoot>();
    }
    private void Update()
    {
        if (inView)
        {
            enemyShoot.enabled = true;
        }
        else
        {
            enemyShoot.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inView = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inView = false;
        }
    }
}
