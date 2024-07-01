using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected int MaxHealth = 1;
    public GameObject fxObject;
    protected int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
    }
    protected void Dead()
    {
        Instantiate(fxObject, transform.position, Quaternion.identity);
        GetComponent<Collider>().enabled = false;
        Destroy(gameObject);
    }
}
