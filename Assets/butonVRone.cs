using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class butonVR : MonoBehaviour
{
    public Transform button;
    public Transform gate;
    public AudioSource sound;

    private bool gateAnimating = false;
    
    public float gateSpeed = 0.01f;

    void LateUpdate()
    {
        

        if (gateAnimating == true && gate.position.z >-1.4f){
            
            gate.position += new Vector3(0,0,-gateSpeed); 
        }
        if (gate.position.z<-1.4f && gateAnimating == true){
            gateAnimating = false;
        }
        

        
    }

    private void OnTriggerEnter(Collider other)
    {
            button.localPosition= new Vector3(0,0.1f,0);
        
            sound.Play();
            
            gateAnimating = true;

    }

    private void OnTriggerExit(Collider other)
    {
            button.localPosition = new Vector3 (0, 0.25f, 0);
            
            
    }

   
      

   
}

    
