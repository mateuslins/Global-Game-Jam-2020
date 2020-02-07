using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class DeployEnemies : MonoBehaviour
{
    public PlayerController player;
    public GameObject enemyPrefab;

    private Vector2 screenBounds;
    private int killCount = 0;
    private int respawnTime = 3;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(EnemyWave());
    }

    private void Update()
    {
        killCount = player.getKillCount();
        if (killCount >= 10 && killCount < 40)
        {
            respawnTime = 2;
        }
        else if (killCount >= 40)
        {
            respawnTime = 1;
        }
    }

    private void SpawnEnemy()
    {
        int aux = Random.Range(0, 4);
        GameObject a = Instantiate(enemyPrefab) as GameObject;
        a.GetComponent<AIDestinationSetter>().target = GameObject.FindGameObjectWithTag("Player").transform;

        switch (aux)
        {
            case 0:
                a.transform.position = new Vector2(-screenBounds.x, -screenBounds.y);
                break;
            case 1:
                a.transform.position = new Vector2(screenBounds.x, screenBounds.y);
                break;
            case 2:
                a.transform.position = new Vector2(-screenBounds.x, screenBounds.y);
                break;
            case 3:
                a.transform.position = new Vector2(screenBounds.x, -screenBounds.y);
                break;
        }

        //a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), Random.Range(-screenBounds.y, screenBounds.y));
    }

    IEnumerator EnemyWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
        }
    }
}
