using System.Collections;
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

    private Animator _animator;
    
    void Awake()
    {
        base.Awake();
        _animator = GetComponent<Animator>();
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
            Vector3 velocity = (goTo - transform.position).normalized;
            SetDir(velocity);
            transform.position += velocity * speed * Time.deltaTime;
            if ((goTo - transform.position).magnitude < 1)
            {
                float angle = Random.Range(0, 2 * Mathf.PI);
                goTo = _manager.center.position + new Vector3(Mathf.Cos(angle),0,Mathf.Sin(angle)) * Random.Range(0,_manager.area);
                //Debug.DrawLine(goTo, goTo + Vector3.up * 5, Color.red, 20);
            }
        }
    }

    private void SetDir(Vector3 velocity)
    {
        int dir = 0;
        if (Mathf.Abs(velocity.x) > Mathf.Abs(velocity.z))
        {
            if (velocity.x > 0) dir = 3;
            else dir = 1;
        }
        else
        {
            if (velocity.z > 0) dir = 0;
            else dir = 2;
        }
        _animator.SetInteger("direction",dir);
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
        _animator.SetTrigger("Dead");
        dead = true;
        _sound.Dead();
    }
}
