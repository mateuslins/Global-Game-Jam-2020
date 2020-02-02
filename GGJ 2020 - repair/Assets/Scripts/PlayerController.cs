using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D body;

    private int killCount = 0;

    //inventory
    public static int pieces = 0;

    //movement
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 10.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
    
    public void IncreaseKillCount()
    {
        killCount += 1;
    }

    private void WinGame()
    {
        if (killCount >= 20)
        {
            SceneManager.LoadScene("Scene1");
        }
    }

    public void CollectPiece()
    {
        pieces += 1;
        Debug.Log("O numero de peças é " + pieces);
    }

    public void DropPieces()
    {
        pieces = 0;
        Debug.Log("Depositou todas as peças na torre");
    }
}
