using System.Collections;
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
    public Animator ScrollView;

    public void Play()
    {
        SceneManager.LoadScene("Scene2");
    }
    public void Credits()
    {
        ScrollView.SetBool("Active",true);
    }
    public void ReturnCredits()
    {
        ScrollView.SetBool("Active", false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
