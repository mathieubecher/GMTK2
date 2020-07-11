using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPS : MonoBehaviour
{
    private TextMeshProUGUI text;
    private List<float> frames;
    
    // Start is called before the first frame update
    void Start()
    {
        frames = new List<float>();
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        frames.Add(Time.deltaTime);
        if (frames.Count > 120) frames.RemoveAt(0);
        float mean = 0;
        foreach (var frame in frames)
        {
            mean += frame;
        }

        mean /= frames.Count;
        text.text = "FPS : " + Mathf.Floor(1/mean);
    }
}
