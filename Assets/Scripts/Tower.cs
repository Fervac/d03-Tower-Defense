using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private bool canShoot = true;

    public GameObject projectile;
    public float projectileSpeed = 10f;

    public enum Type { arcane, arrow, canon };
    public Type type;

    public int damage;
    public int price;
    public float range;
    public float fireRate;

    private void Awake()
    {
        switch (type)
        {
            case Type.arcane:
                damage = 2;
                price = 100;
                range = 200f;
                fireRate = 2f;
                break;
            case Type.arrow:
                damage = 3;
                price = 160;
                range = 250f;
                fireRate = 1.5f;
                break;
            case Type.canon:
                damage = 5;
                price = 150;
                range = 150f;
                fireRate = 2.5f;
                break;
        }
    }

    private void Update()
    {
        if (!transform.parent.CompareTag("MenuSlot"))
        {
            FindClosestEnemy();
        }
    }

    private void FindClosestEnemy()
    {
        float distanceToClosestEnenmy = Mathf.Infinity;
        Enemy closestEnemy = null;
        Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();

        foreach (Enemy currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;

            if (distanceToEnemy < distanceToClosestEnenmy)
            {
                distanceToClosestEnenmy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }


        if (closestEnemy)
        {
            //if (Vector2.Distance(transform.position, closestEnemy.transform.position) < maxRange)
            //{
                Debug.DrawLine(this.transform.position, closestEnemy.transform.position);

                Shoot(closestEnemy);
            //}
        }
    }

    private void Shoot(Enemy target)
    {
        if (canShoot)
        {
            var bullet = Instantiate(projectile, transform.position, Quaternion.identity);

            bullet.GetComponent<Projectile>().target = target.transform;
            bullet.GetComponent<Projectile>().damage = damage;

            canShoot = false;

            StartCoroutine(ShootingCooldown());
        }

        IEnumerator ShootingCooldown()
        {
            yield return new WaitForSeconds(fireRate);

            canShoot = true;
        }
    }
}
