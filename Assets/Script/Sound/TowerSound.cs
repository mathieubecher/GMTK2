using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSound : MonoBehaviour
{
    private AudioSource _source;
    [SerializeField] private List<AudioClip> pew;
 
    void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    public void Pew()
    {
        _source.PlayOneShot(pew[Random.Range(0,pew.Count)]);
    }
}
