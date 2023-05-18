using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerInputs : MonoBehaviour
{

    public InputActionProperty moveForward;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
         float movementValue = moveForward.action.ReadValue<float>();

   
    }
}
