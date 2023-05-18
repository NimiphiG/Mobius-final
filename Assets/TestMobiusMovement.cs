using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;



public class TestMobiusMovement : MonoBehaviour
{
     
    public Transform xrRig;
    public Transform mobius;
    public Transform container;
    public Transform gate;
    public Transform MainContainer;

   


    public bool movementIsOn = true;

    private bool gateMoving = false;
    private bool gatePositive = false;

    private bool limitReached = false;
    private bool limitOne = false;
    private bool limitTwo = false;

    private bool inRange = false;
    private bool rangeOne = false;
    private bool rangeTwo = false;
    private bool turnCounter = false;

    private bool blocked = false;

    public float gateSpeed = 0.01f;
    public float turnSpeed = 25f;

    




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
    
     float  XrRotation = (xrRig.rotation.w*2)*(xrRig.rotation.w*2);
     float  MobiusRotation = (mobius.rotation.w*2)*(mobius.rotation.w*2) ;

        if (movementIsOn)
        {
            
            Debug.Log("Xr Rotation = "+XrRotation);
            Debug.Log("Mobius Rotation = "+MobiusRotation);
            Debug.Log("Range One = "+rangeOne);
            Debug.Log("Range Two = "+rangeTwo);
             Debug.Log("limit One = "+limitOne);
            Debug.Log("limit Two = "+limitTwo);
            Debug.Log("Gate X Pos = "+gate.position.z);
            Debug.Log("Turn Counter = "+turnCounter);

          

            // where are we on the strip 
            if (XrRotation < 1.1f && XrRotation >1f && limitOne == true ){
                rangeOne = true;
            }else{rangeOne = false;
            blocked = false;}

            if (XrRotation < 1f && XrRotation >0.9f && limitTwo == true ){
                rangeTwo = true;
            }else{ rangeTwo = false;
            blocked = false;
                     }

            

           if (rangeOne == true && turnCounter ==false )
           {
                blocked =true;
           }

           if (rangeTwo == true && turnCounter == true )
           {
                blocked =true;
            }
            
            // if (gate.position.z > -2 && gate.position.z <2){
            //      blocked = true;
            // }  

            //move if we can
            if (Keyboard.current[Key.W].isPressed && blocked == false)
            {
               mobius.Rotate(container.up, -turnSpeed * Time.deltaTime, Space.Self);
               xrRig.Rotate(container.forward, -turnSpeed * Time.deltaTime * 0.5f, Space.Self);
            }
            if (Keyboard.current[Key.S].isPressed)
            {
                mobius.Rotate(container.up, turnSpeed * Time.deltaTime, Space.Self);
                xrRig.Rotate(container.forward, turnSpeed * Time.deltaTime * 0.5f, Space.Self);
            }
    
           

            // wheres the gate, can we move it, move it.
            if (gate.position.z < -2){
                 gateMoving = false; 
                 limitOne = false; limitTwo = true; 
            }
            if (gate.position.z > 2){
                 gateMoving = false;
                 limitTwo = false; limitOne = true;  
            }
            


        
            
            
            

            if (gateMoving == true  && limitOne==true)
            {
                 gate.position += new Vector3(0,0,-gateSpeed); 
                 turnCounter = true;
                
                 
                 
            }
            if (gateMoving == true && limitTwo == true)
            {
                 gate.position += new Vector3(0,0,gateSpeed);
                 turnCounter= false;
                 
            }

        }

// gate move attempt 1 
            //  if(gate.position.y > 10){
            //     gateMoving = false;
            // }

            // if(gate.position.y < -10 ){
            //     gateMoving = false;
            // }

            // if (Keyboard.current[Key.Space].isPressed)
            // {
            //     gateMoving = true;
            // }

            // // if ( gateMoving == true  )
            // // {
            // //  gate.position += new Vector3(0,0,gateSpeed);
            // // }

            //  if ( gateMoving == true && LimitTwo == false)
            // {
            //  gateSpeed = 0.01f;
            // }else{
            //     gateSpeed = 0;
            // }
            //  if ( gateMoving == true && LimitOne == false)
            // {
            //  gateSpeed = -0.01f;
            // }else{
            //     gateSpeed = 0;
            // }
            

            // gate.position += new Vector3(0,0,gateSpeed);
             

            

          

            // if (Keyboard.current[Key.A].isPressed)
            // {
            //    xrRig.position += xrRig.right * Time.deltaTime;
            // }

            // if (Keyboard.current[Key.D].isPressed)
            // {
            //     xrRig.position -= xrRig.right * Time.deltaTime;
            // }
       


        // if (!smoothedVersion)
        // {
        //     RaycastHit hit;
        //     Ray ray = new Ray(xrRig.position, -xrRig.up);


        //     if (Physics.Raycast(ray, out hit))
        //     {
        //         Debug.DrawLine(xrRig.position, hit.point, Color.red);
        //         hitPointNormal = hit.normal;

        //     }

        //     xrRig.position = hit.point + (hitPointNormal * distanceFromNormal);

        //     xrRig.rotation = Quaternion.FromToRotation(xrRig.up, hitPointNormal) * xrRig.rotation;
        // }


       
        
        /*

           if (movementIsOn)
        {
            if (Keyboard.current[Key.W].isPressed)
            {
                xrRig.position += xrRig.forward * Time.deltaTime;
            }

            if (Keyboard.current[Key.S].isPressed)
            {
                xrRig.position -= xrRig.forward * Time.deltaTime;
            }

            if (Keyboard.current[Key.A].isPressed)
            {
                xrRig.Rotate(xrRig.up, -turnSpeed * Time.deltaTime, Space.Self);
            }

            if (Keyboard.current[Key.D].isPressed)
            {
                xrRig.Rotate(xrRig.up, turnSpeed * Time.deltaTime, Space.Self);
            }
        }


        else
        {
            float leftRight = width / 2;
            float foreAft = length / 2;
            float safeUp = 1.0f;
            Vector3 forwardL = xrRig.position + xrRig.forward * foreAft + xrRig.right * -leftRight +
                               Vector3.up * safeUp;
            Vector3 forwardR = xrRig.position + xrRig.forward * foreAft + xrRig.right * leftRight +
                               Vector3.up * safeUp;
            Vector3 forwardAFT = xrRig.position + xrRig.forward * -foreAft + xrRig.up * safeUp;

            RaycastHit rchL, rchR, rchAFT;

            GameObject spL, spR, spAft;
            
            //spL = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //spR = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //spAft = GameObject.CreatePrimitive(PrimitiveType.Sphere);

            //spL.transform.position = forwardL;
            //spR.transform.position = forwardR;
            //spAft.transform.position = forwardAFT;



            int distance = 20;
            if (Physics.Raycast(new Ray(forwardL, -xrRig.up), out rchL, distance) &&
                Physics.Raycast(new Ray(forwardR, -xrRig.up), out rchR, distance) &&
                Physics.Raycast(new Ray(forwardAFT, -xrRig.up), out rchAFT, distance))
            {

                Debug.DrawRay(forwardL, -xrRig.up, Color.blue);
                Debug.DrawRay(forwardR, -xrRig.up, Color.blue);
                Debug.DrawRay(forwardAFT, -xrRig.up, Color.blue);

                Vector3 center = (rchL.transform.position + rchR.transform.position + rchAFT.transform.position * 2) / 4;

                Plane p = new Plane(rchL.point, rchR.point, rchAFT.point);
                Vector3 fwd = (rchL.point + rchR.point) * 0.5f - rchAFT.point;

                xrRig.position = (p.normal * distanceFromNormal);
                xrRig.LookAt(xrRig.position + fwd, p.normal);
            }
        }
        */
    }
}


