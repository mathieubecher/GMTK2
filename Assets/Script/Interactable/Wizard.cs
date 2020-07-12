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
        foreach (Mob mob in detect.mobs)
        {
            mob.renderer.material.SetFloat("_Freeze",1);
            mob.gameObject.GetComponent<Mob>().multiplier = 0.5f;
            
        }
    }
}
