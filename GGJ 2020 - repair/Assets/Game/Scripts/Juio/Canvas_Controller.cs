﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Canvas_Controller : MonoBehaviour
{
    [Header("Menu")]
    public Button buttonPlay;
    public Button buttonCredits;
    public Button buttonExit;
    public Animator Creditos;


    public void Play()
    {
        SceneManager.LoadScene("Game");
        Cursor.visible = false;
    }
    public void Credits()
    {
        Creditos.SetBool("Active",true);

        buttonPlay.interactable = false;
        buttonCredits.interactable = false;
    }
    public void ReturnCredits()
    {
        Creditos.SetBool("Active", false);
        buttonPlay.interactable = true;
        buttonCredits.interactable = true;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
