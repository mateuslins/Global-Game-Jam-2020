using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashController : MonoBehaviour
{
    public float time;
    void Update()
    {
        time += Time.deltaTime;

        if (time >= 4f)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
