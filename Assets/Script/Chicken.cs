using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : LifeController
{
    private GameManager _manager;
    
    [Range(0,15)]
    public float speed = 3;

    private float timer = 0;
    private Vector3 goTo;
    
    void Awake()
    {
        base.Awake();
        _manager = FindObjectOfType<GameManager>();
        
        float angle = Random.Range(0, 2 * Mathf.PI);
        goTo = _manager.center.position;
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = (goTo - transform.position).normalized * speed * Time.deltaTime;
        transform.position += velocity;
        if ((goTo - transform.position).magnitude < 1)
        {
            float angle = Random.Range(0, 2 * Mathf.PI);
            goTo = _manager.center.position + new Vector3(Mathf.Cos(angle),0,Mathf.Sin(angle)) * Random.Range(0,_manager.area);
            Debug.DrawLine(goTo, goTo + Vector3.up * 5, Color.red, 20);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.layer == LayerMask.NameToLayer("Mob"))
        {
            actualLife -= other.gameObject.GetComponent<Mob>().damage;
            Destroy(other.gameObject);
        }
    }
}
