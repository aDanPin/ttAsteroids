using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private void FixedUpdate() {
        if (Input.GetKey(KeyCode.W))
            {
                InputEvents.current.moveTriggerEnter();
            }        
    }
}
