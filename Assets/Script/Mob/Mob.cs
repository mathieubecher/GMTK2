using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : LifeController
{
    [Header("Stat")]
    [SerializeField] public float damage = 1;
    [SerializeField] private float speed = 4;
    [HideInInspector] public float multiplier = 1;
    [Header("Timer")]
    [SerializeField] private float counter = 1;
    [SerializeField] private float interval = 350;
    [Header("Score")]
    [SerializeField] private int points = 50;
    [SerializeField] private int coins = 2;

    private Transform _target;
    private Rigidbody _rigidbody;
    void Awake()
    {
        base.Awake();
        GameManager manager = FindObjectOfType<GameManager>();
        _target = manager.chicken.transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 velocity = (_target.position - transform.position);
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
            Debug.Log("ça touche!");    
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
}
