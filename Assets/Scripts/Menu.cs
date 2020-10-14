using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioSource audiosource;
    private bool isPlaying;

    private void Start()
    {
        isPlaying = true;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("ex01");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SetMusic()
    {
        if (isPlaying)
        {
            audiosource.Stop();
            isPlaying = false;
        }
        else
        {
            audiosource.Play();
            isPlaying = true;
        }
    }
}
