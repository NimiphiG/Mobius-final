using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GateAnimation : MonoBehaviour
{
    
    public Transform gate;
    private  bool gateAnimating;
    
    public float gateSpeed = 0.01f;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
if (gateAnimating ==true){
    if (gate.position.z <-0.69f){
        gate.position += new Vector3(0,0,gateSpeed);
    }

     if (gate.position.z >0.69f){
        gate.position += new Vector3(0,0,-gateSpeed);
    }
}
    

    }
}
