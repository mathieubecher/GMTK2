using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    [Range(0,1)]
    public float probaSplitWave = 0.3f;
    public float intervaleWave = 10;
    
    [Header("List")]
    public List<Spawner> spawners;
    public List<Wave> waves;
    public List<Mob> prefabs;
    
    [Header("Debug")]
    public int counterMax;
    public int sizeWave;

    void Start()
    {
        waves = new List<Wave>();
        waves.Add(new Wave(this, 2, spawners[Random.Range(0,spawners.Count)]));
    }

    void Update()
    {
        
        foreach (var wave in waves.ToArray())
        {
            wave.Update();
        }

        counterMax = 0;
        foreach (var wave in waves)
        {
            counterMax += wave.counter;
        }

        sizeWave = waves.Count;
    }
}
