using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Tower
{
    public override void Action()
    {
        Vector3 pos = transform.position;
        pos.z -= pos.y * 0.7660f/0.642788f;
        pos.y = 0;
        
        detect.transform.position = pos;
    }
}
