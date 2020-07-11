using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [HideInInspector] public GameManager manager;
    public List<Mob> mobPrefab;
    public float interval = 1;
    private float timer;
    void Start()
    {
        timer = interval;
        manager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Mob mob = mobPrefab[Random.Range(0, mobPrefab.Count)];
            Instantiate(mob, transform.position, Quaternion.identity);
            timer = interval * mob.GetInterval()/1000;
        }
    }
}
