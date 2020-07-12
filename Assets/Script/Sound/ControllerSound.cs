using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSound : MonoBehaviour
{
    private AudioSource _source;
    [SerializeField] private List<AudioClip> wear;
    [SerializeField] private List<AudioClip> release;
    
    
    void Awake()
    {
        _source = GetComponent<AudioSource>();
    }
    public void Wear()
    {
        _source.PlayOneShot(wear[Random.Range(0,wear.Count)]);
    }
    
    public void Release()
    {
        _source.PlayOneShot(release[Random.Range(0,release.Count)]);
    }
}
