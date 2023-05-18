using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class MobiusMovement : MonoBehaviour
{
    //user input feilds that are mapped to controller buttons

    public Transform xrOrigin;
    public Transform mobius;
    public Transform container;
    public Transform triggerBox;

    public InputActionProperty moveForwardTrigger;
    public InputActionProperty moveBackwardTrigger;
    public InputActionProperty moveForwardGrip;
    public InputActionProperty moveBackwardGrip;

    public UnityEvent loopComplete;

    public AudioSource sound;

    private bool movementIsOn = true;
    private bool speeding = false;
    private bool crash = false;
    private float turnSpeed = 25f;


    // Update is called once per frame
    void LateUpdate()
    {
        float movingForward =  moveForwardTrigger.action.ReadValue<float>();
        float movingBackwards =  moveBackwardTrigger.action.ReadValue<float>();

        float movingForwardMultiplier =  moveForwardGrip.action.ReadValue<float>();
        float movingBackwardsMultiplier =  moveBackwardGrip.action.ReadValue<float>();
       
        // Debug.Log(movementIsOn);

    if (movingForward > 0.9f && movingBackwards > 0.9f && movingForwardMultiplier > 0.9f && movingBackwardsMultiplier > 0.9f ){
        speeding = true;
        mobius.Rotate(container.up, -turnSpeed * 8f * Time.deltaTime , Space.Self);
        xrOrigin.Rotate(container.forward, -turnSpeed *4f * Time.deltaTime  * movingForward, Space.Self);

    }else{ speeding = false; }

    if (speeding == true && movementIsOn == false ){
        movementIsOn = true;
        sound.Play();
        loopComplete.Invoke();
    }

    if (movingForward > 0 && movementIsOn == true && speeding == false){
        turnSpeed = 25f + (movingForwardMultiplier*25f);
        mobius.Rotate(container.up, -turnSpeed * Time.deltaTime * movingForward, Space.Self);
        xrOrigin.Rotate(container.forward, -turnSpeed * Time.deltaTime * 0.5f * movingForward, Space.Self);
    }
    
    if (movingBackwards > 0 && movementIsOn == true && speeding == false){
        turnSpeed = 25f + (movingBackwardsMultiplier*25f);
        mobius.Rotate(container.up, turnSpeed * Time.deltaTime * movingBackwards, Space.Self);
        xrOrigin.Rotate(container.forward, turnSpeed * Time.deltaTime * 0.5f * movingBackwards, Space.Self);
        
    } 
    }

    private void OnTriggerEnter(Collider other){ movementIsOn = false; }

 private void OnTriggerExit(Collider other){ movementIsOn = true;}
}

 