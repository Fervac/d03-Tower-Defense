using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreScreen : MonoBehaviour
{
    public Image rankImg;
    public Text score;
    public GameObject retry;
    public GameObject nextLevel;
    private void Start()
    {
        rankImg.sprite = RankingSystem.Instance.spr;

        score.text = RankingSystem.Instance.score.ToString();

        if (RankingSystem.Instance.victory)
            nextLevel.SetActive(true);
        else
            retry.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
