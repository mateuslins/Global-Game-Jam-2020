using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour
{
    public float Velocity;
    public GameObject Enemy;

    Vector3 lastenemypos;
    void Update()
    {
        if (Enemy)
        {
            transform.position += (Enemy.transform.position - transform.position).normalized * Time.deltaTime * Velocity;
            lastenemypos = Enemy.transform.position;
        }
        else
        {
            Enemy = GameObject.FindWithTag("Enemy");
            if (Enemy)
            {
                transform.position += (Enemy.transform.position - transform.position).normalized * Time.deltaTime * Velocity;
                lastenemypos = Enemy.transform.position;

            }
            else
            {
                transform.position += (lastenemypos - transform.position).normalized * Time.deltaTime * Velocity;
                Destroy(this.gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            Enemy.gameObject.GetComponent<EnemyController>().Died();
        }
    }
}
