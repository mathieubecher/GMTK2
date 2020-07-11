using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int coins = 0;

    public Chicken chicken;
    public Controller controller;
    public List<Mob> mobs;
    // Start is called before the first frame update
    void Start()
    {
        mobs = new List<Mob>();
        Mob[] mobsTab = FindObjectsOfType<Mob>();
        foreach (var mob in mobsTab)
        {
            mobs.Add(mob);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
