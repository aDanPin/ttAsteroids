using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PhisicalView
{
    protected override void Start()
    {
        base.Start();

        InputEvents.current.onMoveTriggerEnter += Move;
        InputEvents.current.onRotateRightTriggerEnter += Rotate;
        InputEvents.current.onRotateLeftTriggerEnter  += Rotate;
    }

    private void Move() {
        SetForce(Vector2.up, moveForce);
    }
}
