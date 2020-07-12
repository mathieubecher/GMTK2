using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpatialController : MonoBehaviour
{
    public AnimationCurve curve;

    public float maxDist = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var source in FindObjectsOfType<AudioSource>())
        {
            float distance = (transform.position - source.transform.position).magnitude;
            if (distance > maxDist) source.volume = 0;
            else source.volume = curve.Evaluate((maxDist - distance) / maxDist);
        }

        
    }
}
