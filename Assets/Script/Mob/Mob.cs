using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Mob : LifeController
{
    [Header("Stat")]
    [SerializeField] public float damage = 1;
    [SerializeField] private float speed = 4;
    [HideInInspector] public float multiplier = 1;
    [Header("Imfos Spawn")]
    [SerializeField] public int counter = 1;
    [SerializeField] public float interval = 350;
    [SerializeField] public float proba = 0.1f;
    [Header("Score")]
    [SerializeField] private int points = 50;
    [SerializeField] private int coins = 2;

    [Header("FX")]
    [SerializeField] public SpriteRenderer renderer;
    [SerializeField] private float _hitTimer;
    private MobSound _sound;
    
    private Transform _target;
    private Rigidbody _rigidbody;
    
    public int freeze;
    [HideInInspector] private bool isfreeze;
    
    void Awake()
    {
        base.Awake();
        _sound = GetComponent<MobSound>();
        GameManager manager = FindObjectOfType<GameManager>();
        manager.mobs.Add(this);
        _target = manager.chicken.transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        FreezeGestor();
        
        
        Vector3 velocity = (_target.position - transform.position);
        if(Mathf.Abs(velocity.x) > 0) transform.localScale = new Vector3(-Mathf.Sign(velocity.x),1,1);
        velocity.y = 0;
        velocity = velocity.normalized * speed * multiplier;
        _rigidbody.velocity = velocity;
        
        if (_hitTimer > 0)
        {
            _hitTimer -= Time.deltaTime;
            renderer.material.SetFloat("_Hit", 1);
        }
        else renderer.material.SetFloat("_Hit", 0);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Attack"))
        {
            if (other.gameObject.TryGetComponent(out Bullet bullet))
            {
                actualLife -= bullet.damage;
                Destroy(other.gameObject);
            }
            else
            {
                actualLife -= 0.5f;
            }
            //Debug.Log("ça touche!");    
            _hitTimer = 0.2f;
        }
        if(actualLife <= 0) Dead();
    }

    void Dead()
    {
        GameManager manager = FindObjectOfType<GameManager>();
        if (manager == null) return;
        
        if (manager.chicken.actualLife > 0)
        {
            manager.coins += coins;
            manager.score += points;
        }
        
        Destroy(this.gameObject);
    }
    public float GetInterval()
    {
        interval -= counter;
        return interval;
    }

    public void FreezeGestor()
    {
        if (freeze > 0 && !isfreeze)
        {
            multiplier = 0.5f;
            renderer.material.SetFloat("_Freeze",1);
            isfreeze = true;

        }
        else if (freeze <= 0 && isfreeze)
        {
            Debug.Log("release");
            multiplier = 1f;
            renderer.material.SetFloat("_Freeze",0);
            isfreeze = false;
        }
    }
}
