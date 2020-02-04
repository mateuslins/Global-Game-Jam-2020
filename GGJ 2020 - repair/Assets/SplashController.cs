using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashController : MonoBehaviour
{
    public GameObject splash;
    public float time;


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= 4f)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("Menu");
        }
    }
}
