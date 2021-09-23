using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputEvents : MonoBehaviour
{
    public static InputEvents current;

    private void Awake() {
        current = this;
    }

    public event Action onMoveTriggerEnter;
    public void moveTriggerEnter() {
        if(onMoveTriggerEnter != null) {
            onMoveTriggerEnter();
        }
    }
}
