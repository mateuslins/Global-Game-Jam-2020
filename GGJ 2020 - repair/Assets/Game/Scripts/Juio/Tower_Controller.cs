using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Controller : MonoBehaviour
{
    [Header("Tower")]
    public GameObject spot;
    public GameObject bullet;
    public float time;
    public Animator towerAnim;

    public PlayerController player;
    private int pieces = 0;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Start()
    {
        towerAnim = GetComponent<Animator>();
    }
    Vector3 lastenemypos;
    void Update()
    {
        if (pieces >= 5)
        {
            towerAnim.SetBool("isFixed", true);
            time += Time.deltaTime;

            if (time >= 1.5f)
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pieces += player.DropPieces();
            Debug.Log("o numero de peças na torre é " + pieces);
        }
    }
}