using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    [Header("Stat")]
    [SerializeField] private float damage = 1;
    [SerializeField] private float speed = 4;
    [SerializeField] private float life = 1;
    [Header("Timer")]
    [SerializeField] private float counter = 1;
    [SerializeField] private float interval = 350;
    [Header("Score")]
    [SerializeField] private int points = 50;
    [SerializeField] private int coins = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Attack"))
        {
            if (other.gameObject.TryGetComponent(out Bullet bullet))
            {
                life -= bullet.damage;
                Destroy(other.gameObject);
            }
            else
            {
                life -= 0.5f;
            }
            Debug.Log("ça touche!");    
        }
        if(life <= 0) Destroy(gameObject);
    }

    void OnDestroy()
    {
        GameManager manager = FindObjectOfType<GameManager>();
        manager.coins += coins;
        manager.score += points;
    }
}
