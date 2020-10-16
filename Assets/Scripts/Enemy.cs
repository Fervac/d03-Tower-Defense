using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public GameObject Paths;
    public List<Transform> wayPointList;

    public int currentWayPoint = 0;
    Transform targetWayPoint;

    public float speed = 4f;

    public int health = 10;

    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "ex04")
        {
            health = 15;
        }

        Paths = GameObject.FindWithTag("Paths");

        AddWaypoints();
    }

    private void AddWaypoints()
    {
        foreach (Transform child in Paths.transform)
        {
            wayPointList.Add(child);
        }
    }

    private void Update()
    {
        // check if we have somewere to walk
        if (currentWayPoint < this.wayPointList.Count - 1)
        {
            if (targetWayPoint == null)
                targetWayPoint = wayPointList[currentWayPoint];
            walk();
        }

        if (currentWayPoint == this.wayPointList.Count - 1)
        {
            Manager.Instance.Hit();

            Destroy(this.gameObject);
        }

        if (health <= 0)
        {
            Manager.Instance.gold += 50;
            RankingSystem.Instance.score += 50;

            Destroy(this.gameObject);
        }
    }

    private void walk()
    {
        // rotate towards the target
        transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, speed * Time.deltaTime, 0.0f);

        // move towards the target
        transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, speed * Time.deltaTime);

        if (transform.position == targetWayPoint.position)
        {
            currentWayPoint++;
            targetWayPoint = wayPointList[currentWayPoint];
        }
    }
}
