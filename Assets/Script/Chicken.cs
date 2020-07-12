﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : LifeController
{
    private GameManager _manager;
    private ChickenSound _sound;
    [Range(0,15)]
    public float speed = 3;

    private float timer = 0;
    private Vector3 goTo;
    public bool dead;
    
    [Header("FX")]
    [SerializeField] public SpriteRenderer renderer;
    [SerializeField] private float _hitTimer;
    
    void Awake()
    {
        base.Awake();
        _manager = FindObjectOfType<GameManager>();
        _sound = GetComponent<ChickenSound>();   
        float angle = Random.Range(0, 2 * Mathf.PI);
        goTo = _manager.center.position;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (_hitTimer > 0)
        {
            _hitTimer -= Time.deltaTime;
            renderer.material.SetFloat("_Hit", 1);
        }
        else renderer.material.SetFloat("_Hit", 0);
        
        
        if(actualLife > 0){
            Vector3 velocity = (goTo - transform.position).normalized * speed * Time.deltaTime;
            transform.position += velocity;
            if ((goTo - transform.position).magnitude < 1)
            {
                float angle = Random.Range(0, 2 * Mathf.PI);
                goTo = _manager.center.position + new Vector3(Mathf.Cos(angle),0,Mathf.Sin(angle)) * Random.Range(0,_manager.area);
                //Debug.DrawLine(goTo, goTo + Vector3.up * 5, Color.red, 20);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.layer == LayerMask.NameToLayer("Mob"))
        {
            float damage = other.gameObject.GetComponent<Mob>().damage;
            actualLife -= damage;
            Destroy(other.gameObject);
            if (actualLife > 0)
            {
                _hitTimer = 0.1f;
                _sound.Hit(damage);
                StartCoroutine(Camera.main.GetComponent<Shake>().AddShake(0.1f, 0.2f));
            }
            else if (!dead) Dead();
            if (actualLife < 0) actualLife = 0;
        }
    }

    public void Dead()
    {
        dead = true;
        _sound.Dead();
    }
}
