using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public AudioSource source;

    public List<AudioClip> jumps;

    public void JumpSound()
    {
        source.PlayOneShot(jumps[Random.Range(0,jumps.Count)]);
    }
}
