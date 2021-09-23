using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PhisicalView
{
    [SerializeField]
    private float moveForce = 10;

    protected override void Start()
    {
        base.Start();

        InputEvents.current.onMoveTriggerEnter += Move;
    }

    private void Move() {
        ExertForce(Vector2.up, moveForce, Time.fixedDeltaTime);
    }
}
