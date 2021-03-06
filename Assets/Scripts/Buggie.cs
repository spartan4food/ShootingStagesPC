﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buggie : MonoBehaviour
{
    public float HP = 100;
    public GameObject deathEffect;

    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
