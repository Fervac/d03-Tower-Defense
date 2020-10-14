using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform target;

    private float speed = 160.0f;
    public int damage;

    private void Update()
    {
        if (target == null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            MoveToTarget();
        }

    }

    private void MoveToTarget()
    {
        Vector3 vectorToTarget = target.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 20f)
        {
            target.GetComponent<Enemy>().health -= damage;
            Destroy(this.gameObject);
        }
    }
}
