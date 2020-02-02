using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour
{
    public float Velocity;
    public GameObject Enemy;
    void Start()
    {
    }

    Vector3 lastenemypos;
    void Update()
    {
        transform.Translate(new Vector2(Velocity * Time.deltaTime, 0));
        if (this.gameObject.activeSelf)
        {
            if (Enemy)
            {
                transform.position += (Enemy.transform.position - transform.position) * Time.deltaTime * Velocity;
                lastenemypos = Enemy.transform.position;

            }
            else
            {
                Enemy = GameObject.FindWithTag("Enemy");
                if (Enemy)
                {
                    transform.position += (Enemy.transform.position - transform.position) * Time.deltaTime * Velocity;
                    lastenemypos = Enemy.transform.position;

                }
                else
                {
                    transform.position += (lastenemypos - transform.position) * Time.deltaTime * Velocity;
                    Destroy(this.gameObject, 1f);

                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
