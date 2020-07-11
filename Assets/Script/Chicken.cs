﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : LifeController
{

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.layer == LayerMask.NameToLayer("Mob"))
        {
            actualLife -= other.gameObject.GetComponent<Mob>().damage;
            Destroy(other.gameObject);
        }
    }
}