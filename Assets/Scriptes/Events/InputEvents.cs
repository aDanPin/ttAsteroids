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

    public event Action<Vector2> onRotateRightTriggerEnter;
    public void rotateRightTriggerEnter() {
        if(onRotateRightTriggerEnter != null) {
            onRotateRightTriggerEnter(Vector2.right);
        }
    }

    public event Action<Vector2> onRotateLeftTriggerEnter;
    public void rotateLeftTriggerEnter() {
        if(onRotateLeftTriggerEnter != null) {
            onRotateLeftTriggerEnter(Vector2.left);
        }
    }

    public event Action onFierTriggerEnter;
    public void fierTriggerEnter() {
        if(onFierTriggerEnter != null) {
            onFierTriggerEnter();
        }
    }
}
