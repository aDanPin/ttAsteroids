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
        if (Input.GetKey(KeyCode.Q))
        {
            InputEvents.current.rotateLeftTriggerEnter();
        }
        if (Input.GetKey(KeyCode.E))
        {
            InputEvents.current.rotateRightTriggerEnter();
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InputEvents.current.fierTriggerEnter();
        }
        if (Input.GetKey(KeyCode.V))
        {
            InputEvents.current.laserTriggerEnter();
        }
    }
}
