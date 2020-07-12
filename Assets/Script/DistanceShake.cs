using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceShake : MonoBehaviour
{
    private Shake _shake;
    private Controller _controller;
    public float force = 0.05f;
    public float distance = 10f;
    public float duration = 0.1f;

    void Awake()
    {
        _shake = Camera.main.GetComponent<Shake>();
        _controller = FindObjectOfType<GameManager>().controller;
    }
    public void StartShake()
    {
        StartCoroutine(_shake.AddShake(duration, force * Mathf.Max(0,(distance-(_controller.transform.position-transform.position).magnitude) /distance)));
    }

}
