using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour
{
    [SerializeField] public List<Mob> mobs;

    void Awake()
    {
        mobs = new List<Mob>();
    }
    
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        mobs.Add(other.gameObject.GetComponent<Mob>());    
    }

    void OnTriggerExit(Collider other)
    {
        mobs.Remove(other.gameObject.GetComponent<Mob>());    
    }

    public Mob GetNear()
    {
        mobs.RemoveAll( x=> x == null);
        if(mobs.Count == 0) return null;
        else
        {
            Mob near = mobs[0];
            for (int i = 1; i < mobs.Count; ++i)
            {
                if ((near.transform.position - transform.position).magnitude > (mobs[i].transform.position - transform.position).magnitude) near = mobs[i];
            }
            return near;
        }
    }
}
