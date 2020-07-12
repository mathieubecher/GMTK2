using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSound : MonoBehaviour
{
    
    private AudioSource _source;
    [SerializeField] private List<AudioClip> dead;
    
    void Awake()
    {
        _source = GetComponent<AudioSource>();
    }
    public void Dead()
    {
        _source.PlayOneShot(dead[Random.Range(0,dead.Count)]);
    }
}
