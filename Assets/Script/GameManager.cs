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
    
    [Header("Mob")]
    public Chicken chicken;
    public Controller controller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #if UNITY_EDITOR
    void OnDrawGizmos()
    {
        
        Handles.color = Color.white;
        Handles.DrawWireDisc(center.position,Vector3.up,area);
    }
    #endif
    
}
