using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake() {
        current = this;
    }

    public event Action<Vector2, float> onAsteroidDestroyTriggerEnter;
    public void asteroidDestroyTriggerEnter(Vector2 pos, float speed) {
        if(onAsteroidDestroyTriggerEnter != null) {
            onAsteroidDestroyTriggerEnter(pos, speed);
        }
    }
}
