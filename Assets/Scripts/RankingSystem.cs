using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RankingSystem : MonoBehaviour
{
    public int score;

    public Sprite spr;

    public List<Sprite> ranks;

    public bool victory = false;

    #region SINGLETON PATTERN
    public static RankingSystem _instance;
    public static RankingSystem Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<RankingSystem>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("RankingSystem");
                    _instance = container.AddComponent<RankingSystem>();
                }
            }

            return _instance;
        }
    }
    #endregion

    public void FinalScore(bool win)
    {
        score += Manager.Instance.life * 100;

        if (win)
        {
            victory = true;

            score += 500;
        }

        spr = ranks[0];

        if (score > 500)
            spr = ranks[1];
        if (score > 1000)
            spr = ranks[2];
        if (score > 2000)
            spr = ranks[3];
        if (score > 3000)
            spr = ranks[4];

        SceneManager.LoadScene("ex03");
    }
}
