﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonPew : MonoBehaviour
{
    public Tower prefab;
    private GameManager _manager;

    void Awake()
    {
        _manager = FindObjectOfType<GameManager>();
    }

    public void OnClick()
    {
        if (_manager.coins > prefab.price && _manager.controller.couldCreate)
        {
            Debug.Log("create");
            _manager.coins -= prefab.price;
            Tower tower = Instantiate(prefab, _manager.controller.transform.position, Quaternion.identity);
            _manager.controller.interactTo = tower;
            _manager.controller.state.Interact();
            
        }
        EventSystem.current.SetSelectedGameObject(null);
    } 
}