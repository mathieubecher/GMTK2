using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public float life;
    [HideInInspector] public float actualLife;
    // Start is called before the first frame update
    protected void Awake()
    {
        actualLife = life;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
