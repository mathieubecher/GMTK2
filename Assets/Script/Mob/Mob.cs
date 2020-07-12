using System.Collections;
using System.Collections.Generic;
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

    private Transform _target;
    private Rigidbody _rigidbody;
    void Awake()
    {
        base.Awake();
        GameManager manager = FindObjectOfType<GameManager>();
        manager.mobs.Add(this);
        _target = manager.chicken.transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 velocity = (_target.position - transform.position);
        if(Mathf.Abs(velocity.x) > 0) transform.localScale = new Vector3(-Mathf.Sign(velocity.x),1,1);
        velocity.y = 0;
        velocity = velocity.normalized * speed * multiplier;
        _rigidbody.velocity = velocity;
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
        }
        if(actualLife <= 0) Dead();
    }

    void Dead()
    {
        GameManager manager = FindObjectOfType<GameManager>();
        if (manager == null) return;
        manager.coins += coins;
        manager.score += points;
        Destroy(this.gameObject);
    }
    public float GetInterval()
    {
        interval -= counter;
        return interval;
    }
}
