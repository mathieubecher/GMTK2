using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfosGestor : MonoBehaviour
{    
    private GameManager _manager;

    [SerializeField] private TextMeshProUGUI fps;
    // Start is called before the first frame update
    void Start()
    {
        _manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift)) fps.gameObject.SetActive(true);
    }
}
