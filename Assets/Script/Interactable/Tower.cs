using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tower : Interactable
{
    private TowerSound _sound;
    [Header("Stat")]
    public float damage;
    public float cadence;
    [Range(0,100)] public float area;
    [SerializeField] private GameObject bullet;
    public int price = 10;

    [Header("Upgrade")] 
    public Tower upgrade;
    
    [Header("Infos")]
    private float timer;
    [SerializeField] private Detect detect;
    [SerializeField] private Transform bulletSpawnPos;

    private void Awake()
    {
        FindObjectOfType<GameManager>().towers.Add(this);
        existUpgrade = upgrade != null;
        base.Awake();
        detect.GetComponent<SphereCollider>().radius = area;
        _sound = GetComponent<TowerSound>();   
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
                Shoot(mob);
                Debug.DrawLine(transform.position, mob.transform.position, Color.red, 0.5f);
            }
            
        }
    }
    
    public override void Upgrade()
    {
        GameManager manager = FindObjectOfType<GameManager>();
        if (manager.coins >= upgrade.price)
        {
            Debug.Log("could upgrade");
            Tower upgradeInstance = Instantiate(upgrade, transform.position, Quaternion.identity);
            ((InteractState) manager.controller.state)._interactable = upgradeInstance;
            upgradeInstance.Wear(manager.controller);
            
            manager.coins -= upgrade.price;
            Destroy(this.gameObject);
            
        }
    }

    private void Shoot(Mob mob)
    {
        _sound.Pew();
        GameObject bulletObject = Instantiate(bullet, bulletSpawnPos.position, Quaternion.identity);
        Bullet bulletInstance = bulletObject.GetComponent<Bullet>();
        bulletInstance.damage = damage;
        bulletInstance.target = mob;
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
