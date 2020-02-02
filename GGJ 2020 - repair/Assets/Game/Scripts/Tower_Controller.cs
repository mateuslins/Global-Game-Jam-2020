using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Controller : MonoBehaviour
{
    [Header("Tower")]
    public GameObject spot;
    public GameObject bullet;
    public float time;
    //public Animator towerAnim;

    void Start()
    {

    }
    Vector3 lastenemypos;
    void Update()
    {
        time += Time.deltaTime;

        if (time >= 0.5)
        {
            var enemy = GameObject.FindWithTag("Enemy");
            if (enemy == null)
            {
                time = 0;
                return;
            }
            Instantiate(bullet, new Vector3(spot.transform.position.x, spot.transform.position.y, spot.transform.position.z), spot.transform.rotation).GetComponent<Bullet_Controller>().Enemy = enemy;
            time = 0;
        }
    }
}