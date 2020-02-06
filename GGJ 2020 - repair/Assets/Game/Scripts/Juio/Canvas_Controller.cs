using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Canvas_Controller : MonoBehaviour
{
    public LevelLoader levelLoader;
    [Header("Menu")]
    public Button buttonPlay;
    public Button buttonCredits;
    public Button buttonExit;
    public Animator animCredits;
    public bool CreditsMove;

    public void Play()
    {
        levelLoader.LoadNextScene(1);
        Cursor.visible = false;
    }
    public void Credits()
    {
        CreditsMove = !CreditsMove;

        if (CreditsMove)
        {
            animCredits.SetBool("Active", true);
        }

        buttonPlay.interactable = false;
        buttonCredits.interactable = false;
    }
    public void ReturnCredits()
    {
        CreditsMove = !CreditsMove;

        if (!CreditsMove)
        {
            animCredits.SetBool("Active", false);
        }

        buttonPlay.interactable = true;
        buttonCredits.interactable = true;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
