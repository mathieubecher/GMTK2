using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonPew : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Tower prefab;
    private GameManager _manager;
    public Text price;
    public GameObject Locked;
    public GameObject Button;
    private Animator Button_Animator;

    void Start()
    {
        Button_Animator = Button.GetComponent<Animator>();
    }

    void Awake()
    {
        price.text = ""+Mathf.Floor(prefab.price);
        _manager = FindObjectOfType<GameManager>();

        
    }

    void Update()
    {
        if (_manager.IsInteractible() == true)
        {
            Locked.SetActive(true);
        }
        else
        {
            if (Mathf.Floor(prefab.price) > _manager.coins)
            {
                Locked.SetActive(true);
            }
            else
            {
                if (_manager.towers.Count == _manager.maxTower)
                {
                    Locked.SetActive(true);
                } else
                {
                    Locked.SetActive(false);
                }
                
            }
        }

        if (Mathf.Floor(prefab.price) > _manager.coins)
        {
            price.GetComponent<Text>().color = new Color(0.7843137f, 0.2117647f, 0.1843137f);
        }
        else
        {
            price.GetComponent<Text>().color = new Color(0.8705882f, 0.8196079f, 0.5843138f);
        }
    }

    public void OnClick()
    {
        if (_manager.coins >= prefab.price && _manager.towers.Count < _manager.maxTower && _manager.controller.couldCreate)
        {
            Debug.Log("create");
            _manager.coins -= prefab.price;
            Tower tower = Instantiate(prefab, _manager.controller.transform.position, Quaternion.identity);
            _manager.controller.interactTo = tower;
            _manager.controller.state.Interact();
        }
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Button_Animator.SetBool("Over", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Button_Animator.SetBool("Over", false);
    }
}
