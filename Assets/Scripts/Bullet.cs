﻿using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject particle;
    private Transform target;
    public float speed = 50f;
    private int enemyWorth = 150;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(particle, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        // Kill enemy
        Destroy(target.gameObject);
        // Destroy bullet
        Destroy(gameObject);

        Debug.Log("+= 100");
        PlayerStats.Money += enemyWorth;
    }
}

