﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{

    public IEnumerator AddShake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime; 
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            transform.localPosition =  new Vector3(x,y,originalPos.z);
            
            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
