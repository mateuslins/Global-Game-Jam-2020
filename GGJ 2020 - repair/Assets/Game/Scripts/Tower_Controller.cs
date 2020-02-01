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

    void Update()
    {
        time += Time.deltaTime;
        if (time >= 0.5)
        {
            Shooting();
            time = 0;
        }
    }
    void Shooting()
    {
        Instantiate(bullet, new Vector3(spot.transform.position.x, spot.transform.position.y, spot.transform.position.z),spot.transform.rotation);
    }
}