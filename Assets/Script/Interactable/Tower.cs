using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Interactable
{
    public float cadence;
    private float timer;
    public override void Action()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = cadence;
            pew.gameObject.SetActive(true);
            
        }
        else if (timer < cadence - 0.3f)
        {
            pew.gameObject.SetActive(false);
        }
    }

    public override void Wear(Controller controller)
    {
        timer = cadence;
        base.Wear(controller);
    }
}
