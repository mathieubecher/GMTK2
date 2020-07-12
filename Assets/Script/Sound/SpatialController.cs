using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpatialController : MonoBehaviour
{
    public struct SoundEnd
    {
        public AudioSource source;
        public float endVolume;

        public SoundEnd(AudioSource source, float volume)
        {
            this.source = source;
            endVolume = volume;
        }
    }
    public AnimationCurve curve;

    public float maxDist = 50;

    private GameManager manager;

    private List<SoundEnd> ends;
    
    public float endTimerMax = 3;
    private float endTimer;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        ends = new List<SoundEnd>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.chicken.actualLife > 0)
        {
            foreach (var source in FindObjectsOfType<AudioSource>())
            {
                if (!source.TryGetComponent(out IgnoreSpatial _))
                {
                    float distance = (transform.position - source.transform.position).magnitude;
                    if (distance > maxDist) source.volume = 0;
                    else source.volume = curve.Evaluate((maxDist - distance) / maxDist);
                }
            }
        }
        else if(ends.Count > 0 && endTimer > 0)
        {
            endTimer -= Time.deltaTime;
            foreach (var end in ends)
            {
                end.source.volume = end.endVolume * endTimer/endTimerMax;
            }
        }
    }
    public void Dead()
    {
        endTimer = endTimerMax;
        foreach (var source in FindObjectsOfType<AudioSource>())
        {
            if(!source.TryGetComponent(out IgnoreSpatial _))
            { 
                if (!source.TryGetComponent(out Chicken chick))
                {
                    ends.Add(new SoundEnd(source, source.volume));
                }
                else
                {
                    Debug.Log(chick.GetType().ToString());
                    source.volume = 1;
                }
                
            }
           
        }
    }
}
