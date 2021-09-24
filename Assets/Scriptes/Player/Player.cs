using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PhisicalView
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float speedOfBullet;

    protected override void Start()
    {
        base.Start();

        InputEvents.current.onMoveTriggerEnter += Move;
        InputEvents.current.onRotateRightTriggerEnter += Rotate;
        InputEvents.current.onRotateLeftTriggerEnter  += Rotate;
        InputEvents.current.onFierTriggerEnter += Fier;
    }

    private void Move() {
        SetForce(Vector2.up, moveForce);
    }

    private void Fier() {
        var bulletView = Instantiate(bullet, GetPosition(),Quaternion.identity)
                             .GetComponent<IPhisicalView>();

        Vector2 speedDirection = Utils.Rotate(Vector2.up, GetRotation()); 

        bulletView.SetValueToInit(GetRotation(),
                                  speedDirection,
                                  speedOfBullet);
    }
}
