using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseScreen;

    public float TimeSpeed = 1f;

    public void ChangeSpeed(int i)
    {
        switch (i)
        {
            case 0:
                TimeSpeed = 0.5f;
                break;
            case 1:
                TimeSpeed = 1f;
                break;
            case 2:
                TimeSpeed = 2f;
                break;
            case 3:
                pauseScreen.SetActive(false);
                break;
        }

        Time.timeScale = TimeSpeed;
    }

    public void Retry()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void Quit()
    {
        SceneManager.LoadScene("ex00");
    }
}
