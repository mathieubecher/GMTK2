using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatAss : MonoBehaviour
{
    public AudioClip poisson;
    public AudioSource chickenSource;
    public float area = 50;
    private Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = _camera.WorldToScreenPoint(transform.position);   
        Debug.Log(Input.mousePosition +" "+ pos);
        if ((Input.mousePosition - pos).magnitude < area) {
            if(Input.GetMouseButtonDown(0)) chickenSource.PlayOneShot(poisson);
        }
    }
}
