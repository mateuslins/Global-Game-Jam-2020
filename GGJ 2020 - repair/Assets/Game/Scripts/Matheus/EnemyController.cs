using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public Animator animEnemy;
    private AudioController audioController;

    private void Start()
    {
        audioController = FindObjectOfType(typeof(AudioController)) as AudioController;
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            var play = col.gameObject.GetComponent<PlayerController>();
            play.Died();
            Cursor.visible = true;
        }
    }
    public void Died()
    {
        animEnemy.SetBool("Died", true);
        audioController.playSfx(audioController.sfxEnemyDied, 0.5f);
    }
}
