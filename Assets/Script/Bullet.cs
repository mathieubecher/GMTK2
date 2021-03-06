﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Mob target;
    [SerializeField,Range(0,20)] public float speed = 5;
    public float damage = 1;
    
    void Update()
    {
        if(target == null) Destroy(this.gameObject);
        else transform.position += (target.transform.position - transform.position).normalized * speed * Time.deltaTime;
    }
}
