using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeArea : Detect
{
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        mobs.Add(other.gameObject.GetComponent<Mob>());
        other.gameObject.GetComponent<Mob>().multiplier = 0.5f;
    }
    void OnTriggerExit(Collider other)
    {
        mobs.Remove(other.gameObject.GetComponent<Mob>());   
        other.gameObject.GetComponent<Mob>().multiplier = 1f;
    }
}
