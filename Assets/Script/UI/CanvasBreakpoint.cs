using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasBreakpoint : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Canvas_SmallResolution;
    public GameObject Canvas_BigResolution;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Screen.height > 750)
        {
            Canvas_SmallResolution.SetActive(false);
            Canvas_BigResolution.SetActive(true);
        } else
        {
            Canvas_SmallResolution.SetActive(true);
            Canvas_BigResolution.SetActive(false);
        }
    }
}
