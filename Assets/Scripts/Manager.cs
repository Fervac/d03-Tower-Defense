using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject EnemyPrefab;

    public GameObject GameOverScreen;
    public GameObject PauseScreen;

    public GameObject Arcane;
    public GameObject Arrow;
    public GameObject Canon;

    public Text goldText;
    public int gold = 100;

    public Text lifeText;
    public int life = 10;

    public int wave = 0;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    #region SINGLETON PATTERN
    public static Manager _instance;
    public static Manager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Manager>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("Manager");
                    _instance = container.AddComponent<Manager>();
                }
            }

            return _instance;
        }
    }
    #endregion

    private void Start()
    {
        Time.timeScale = 1f;

        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);

        GameOverScreen = GameObject.FindWithTag("GameOver");
        GameOverScreen.SetActive(false);

        InvokeRepeating("Spawn", 2f, 3f);
        InvokeRepeating("Payday", 2f, 2f);
    }

    private void Update()
    {
        goldText.text = gold.ToString();
        lifeText.text = life.ToString();

        if (wave > 40)
        {
            Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();
            if (allEnemies.Length == 0)
            {
                GameOver(true);
            }
        }
    }

    public string GetPrice(Tower.Type type)
    {
        string tmp = null;

        switch (type)
        {
            case Tower.Type.arcane:
                tmp = Arcane.GetComponent<Tower>().price.ToString();
                break;
            case Tower.Type.arrow:
                tmp = Arrow.GetComponent<Tower>().price.ToString();
                break;
            case Tower.Type.canon:
                tmp = Canon.GetComponent<Tower>().price.ToString();
                break;
        }
        return tmp;
    }

    public string GetDamage(Tower.Type type)
    {
        string tmp = null;

        switch (type)
        {
            case Tower.Type.arcane:
                tmp = Arcane.GetComponent<Tower>().damage.ToString();
                break;
            case Tower.Type.arrow:
                tmp = Arrow.GetComponent<Tower>().damage.ToString();
                break;
            case Tower.Type.canon:
                tmp = Canon.GetComponent<Tower>().damage.ToString();
                break;
        }
        return tmp;
    }

    public string GetFireRate(Tower.Type type)
    {
        string tmp = null;

        switch (type)
        {
            case Tower.Type.arcane:
                tmp = Arcane.GetComponent<Tower>().fireRate.ToString();
                break;
            case Tower.Type.arrow:
                tmp = Arrow.GetComponent<Tower>().fireRate.ToString();
                break;
            case Tower.Type.canon:
                tmp = Canon.GetComponent<Tower>().fireRate.ToString();
                break;
        }
        return tmp;
    }

    public string GetRange(Tower.Type type)
    {
        string tmp = null;

        switch (type)
        {
            case Tower.Type.arcane:
                tmp = Arcane.GetComponent<Tower>().range.ToString();
                break;
            case Tower.Type.arrow:
                tmp = Arrow.GetComponent<Tower>().range.ToString();
                break;
            case Tower.Type.canon:
                tmp = Canon.GetComponent<Tower>().range.ToString();
                break;
        }
        return tmp;
    }

    private void Payday()
    {
        gold += 10;
    }

    private void Spawn()
    {
        wave += 1;
        if (wave <= 40)
        {
            Instantiate(EnemyPrefab, new Vector3(1240, 315, -0.1f), Quaternion.identity);
        }
    }

    public void Hit()
    {
        life -= 1;

        if (life <= 0)
        {
            GameOver(false);
        }
    }

    public void GameOver(bool win)
    {
        RankingSystem.Instance.FinalScore(win);

        GameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PauseMenu()
    {
        PauseScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
