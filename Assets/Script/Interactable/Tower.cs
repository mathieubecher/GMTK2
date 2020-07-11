using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tower : Interactable
{
    [Header("Stat")]
    public float cadence;
    [Range(0,100)] public float area;
    [SerializeField] private GameObject bullet;
    public int price = 10;
    
    [Header("Infos")]
    private float timer;
    [SerializeField] private Detect detect;

    private void Awake()
    {
        base.Awake();
        detect.GetComponent<SphereCollider>().radius = area;
    }
    
    public override void Action()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = cadence;
            Mob mob = detect.GetNear();
            if (mob != null)
            {
                pew.gameObject.SetActive(true);
                Shoot(mob);
                Debug.DrawLine(transform.position, mob.transform.position, Color.red, 0.5f);
            }
            
        }
        else if (timer < cadence - 0.3f)
        {
            pew.gameObject.SetActive(false);
        }
    }

    private void Shoot(Mob mob)
    {
        GameObject bulletObject = Instantiate(bullet, transform.position, Quaternion.identity);
        bulletObject.GetComponent<Bullet>().target = mob;
    }

    public override void Wear(Controller controller)
    {
        timer = cadence;
        base.Wear(controller);
    }

    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position,Vector3.up,area);
    }
    #endif
}
