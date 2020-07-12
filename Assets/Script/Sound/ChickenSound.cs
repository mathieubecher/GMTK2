using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSound : MonoBehaviour
{
    private AudioSource _source;
    [SerializeField] private List<AudioClip> hit;

    private float timer = 0;
    [SerializeField] private List<AudioClip> idle;
    [SerializeField] private AudioClip dead;
    private bool isdead;
    
    void Awake()
    {
        timer = Random.Range(0, 30);
        _source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isdead) return;
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = Random.Range(10, 30);
            Iddle();
        }
    }

    public void Hit(float damage)
    {
        _source.PlayOneShot(hit[Random.Range(0,hit.Count)]);
    }

    public void Iddle()
    {
        _source.PlayOneShot(idle[Random.Range(0,idle.Count)]);
    }

    public void Dead()
    {
        Debug.Log("dafuck");
        FindObjectOfType<SpatialController>().Dead();
        _source.PlayOneShot(dead);
        isdead = true;
        
    }
}
