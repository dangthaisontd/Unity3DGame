using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : Enemy,IDamageble
{
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Dead();
        }       
    }
}
