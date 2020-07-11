using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Stat")]
    public int score = 0;
    public int coins = 0;
    
    [Header("Infos")]
    public Transform center;
    public float area = 100;
    public int maxTower = 100;
    
    [Header("Mob")]
    public Chicken chicken;
    public Controller controller;
    public List<Tower> towers;
    public List<Mob> mobs;
    public List<Spawner> spawners;

    // Start is called before the first frame update
    void Start()
    {
        Spawner[] listSpawner = FindObjectsOfType<Spawner>();
        foreach (var spawner in listSpawner)
        {
            spawners.Add(spawner);
        }
    }

    // Update is called once per frame
    void Update()
    {
        towers.RemoveAll(x=>x == null);
        mobs.RemoveAll(x=>x == null);
    }

    #if UNITY_EDITOR
    void OnDrawGizmos()
    {
        
        Handles.color = Color.white;
        Handles.DrawWireDisc(center.position,Vector3.up,area);
    }
    #endif
    
}
