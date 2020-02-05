using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private AudioController audioController;

    public Rigidbody2D body;
    public Text keysNumber;
    public Text killCountText;

    private int killCount = 0;

    //Animação
    private Animator animPlayer;
    public bool moving;

    //inventory
    public static int pieces = 0;

    //movement
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    private bool isLookLeft;

    public float runSpeed = 10.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animPlayer = GetComponent<Animator>();
        audioController = FindObjectOfType(typeof(AudioController)) as AudioController;
    }

    void Update()
    {
        Animacao();

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        float h = Input.GetAxis("Horizontal"); // FLIPPAR DIREITA/ESQUERDA
        if (h > 0 && isLookLeft == true)
        {
            Flip();
        }
        else if (h < 0 && isLookLeft == false)
        {
            Flip();
        }

        keysNumber.text = pieces.ToString();
        killCountText.text = "Killcount: " + killCount.ToString();
    }
    private void Animacao()
    {
        animPlayer.SetBool("Run", moving);
    }
    public void Died()
    {
        animPlayer.SetBool("Died", true);
        audioController.playSfx(audioController.sfxPlayerDied, 0.5f);
        audioController.musicSource.Stop();
        pieces = 0;
    }

    public void NextScene()
    {
        SceneManager.LoadScene("Menu");
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
        Debug.Log("numero de kills: " + killCount);
        WinGame();
    }

    private void WinGame()
    {
        if (killCount >= 200)
        {
            audioController.musicSource.Stop();
            SceneManager.LoadScene("Menu");
        }
    }

    public void CollectPiece()
    {
        pieces += 1;
        audioController.playSfx(audioController.sfxPick, 0.8f);
        Debug.Log("O numero de peças é " + pieces);
    }

    public int DropPieces()
    {
        int aux = pieces;
        pieces = 0;
        audioController.playSfx(audioController.sfxFixTower, 0.5f);
        Debug.Log("Depositou todas as peças na torre");
        return aux;
    }
    void Flip()
    {
        isLookLeft = !isLookLeft;
        GetComponent<SpriteRenderer>().flipX = isLookLeft;
    }
}
