using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeArea : Detect
{
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        Mob mob = other.gameObject.GetComponent<Mob>();
        ++mob.freeze;

    }
    void OnTriggerExit(Collider other)
    {
        Mob mob = other.gameObject.GetComponent<Mob>();
        --mob.freeze;
    }
}
