using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class flashingLight : MonoBehaviour
{
    public Light _Light;

    public float minTime;
    public float maxTime;
    private float Timer;

    public AudioSource AS;
    public AudioClip lightingAudio;



    // Start is called before the first frame update
    void Start()
    {
        Timer = Random.Range(minTime,maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer>=0)
        {
        Timer -= Time.deltaTime;
        }

        if(Timer <0.5 ){
            _Light.intensity = 10;
        }
        
       if (Timer < 0){
        _Light.intensity =0;
       }

       if(_Light.intensity == 0)
       {
        Timer = Random.Range(minTime,maxTime);
       }
    }

   

   
}
