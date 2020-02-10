﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Canvas_Controller : MonoBehaviour
{
    public LevelLoader levelLoader;
    private AudioController audioController;
    [Header("Menu")]
    public Button buttonPlay;
    public Button buttonCredits;
    public Button buttonExit;
    public Animator animCredits;
    public bool CreditsMove;
    [Header("Win")]
    public Button buttonMenu;
    [Header("Lose")]
    public Button buttonPlayAgain;
    public Button buttonBackMenu;

    private void Start()
    {
        audioController = FindObjectOfType(typeof(AudioController)) as AudioController;
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            audioController.musicSource.Pause();
            audioController.playSfx(audioController.sfxLose, 1f);
            Cursor.visible = true;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            audioController.musicSource.Pause();
            audioController.playSfx(audioController.sfxWin, 1f);
            Cursor.visible = true;
        }
    }
    public void Play()
    {
        audioController.playSfx(audioController.sfxButton, 0.5f);
        levelLoader.LoadNextScene(1);
        Cursor.visible = false;
    }
    public void Credits()
    {
        CreditsMove = !CreditsMove;
        audioController.playSfx(audioController.sfxButton, 0.5f);
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
        audioController.playSfx(audioController.sfxButton, 0.5f);
        if (!CreditsMove)
        {
            animCredits.SetBool("Active", false);
        }

        buttonPlay.interactable = true;
        buttonCredits.interactable = true;
    }
    public void Exit()
    {
        audioController.playSfx(audioController.sfxButton, 0.5f);
        Debug.LogError("Exit");
        Application.Quit();
    }
    public void BackMenuLose()
    {
        audioController.playSfx(audioController.sfxButton, 0.5f);
        levelLoader.LoadNextScene(-3);
        audioController.musicSource.Play();
    }
    public void BackMenuWin()
    {
        audioController.playSfx(audioController.sfxButton, 0.5f);
        levelLoader.LoadNextScene(-2);
        audioController.musicSource.Play();
    }
    public void PlayAgain()
    {
        audioController.playSfx(audioController.sfxButton, 0.5f);
        levelLoader.LoadNextScene(-2);
        audioController.musicSource.Play();
        Cursor.visible = false;
    }
}
