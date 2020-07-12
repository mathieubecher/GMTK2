using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public bool active = true;

    protected BoxCollider collider;
    [HideInInspector] public bool existUpgrade = false;

    protected void Awake()
    {
        collider = GetComponent<BoxCollider>();
    }
    // Update is called once per frame
    void Update()
    {
        if(active) Action();
    }

    public virtual void Action()
    {
        
    }

    public virtual void Wear(Controller controller)
    {
        collider.enabled = false;
        transform.position = controller.wearPoint.wearPoint.position;
        transform.SetParent(controller.wearPoint.wearPoint.transform);
        active = true;
    }

    public virtual void Release(Vector3 position)
    {
        transform.parent = null;
        collider.enabled = true;
        transform.position = position;
        active = true;
    }

    public virtual void Upgrade()
    {
        return;
    }
}
