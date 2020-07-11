﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public enum Direction
    {
        Top, Bottom,Right, Left
    }
    
    [HideInInspector] public Rigidbody rigidbody;
    [HideInInspector] public Vector2 velocity;
    [HideInInspector] public AbstractState state;
    //[HideInInspector]
    public Interactable interactTo;

    [Header("Controller")]
    [Range(0, 10),SerializeField] public float speed = 3;

    public Direction direction;
    
    public WearPoint wearPoint;
    
    public TextMeshPro debugState;

    [Header("Input")] 
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    private bool releaseInteract = true;
    
    [SerializeField] private KeyCode attackKey = KeyCode.Space;
    private bool releaseAttack = true;


    // Start is called before the first frame update
    void Start()
    {
        state= new IdleState(this);
        rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        velocity = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        if (velocity.magnitude > 1) velocity.Normalize();
        state.SetDirection();
        state.Update();

        // Attack
        if (Input.GetKey(attackKey) && releaseAttack)
        {
            releaseAttack = false;
            state.Attack();
        }
        else if (!Input.GetKey(attackKey)) releaseAttack = true;
        
        // Interact
        if (Input.GetKey(interactKey) && releaseInteract)
        {
            releaseInteract = false;
            state.Interact();
        }
        else if (!Input.GetKey(interactKey)) releaseInteract = true;

    }

    void OnTriggerEnter(Collider col)
    {
        interactTo = col.gameObject.GetComponent<Interactable>();
    }

    void OnTriggerExit(Collider col)
    {
        if (interactTo != null && interactTo.GetComponent<Interactable>() == interactTo) interactTo = null;
    }
}