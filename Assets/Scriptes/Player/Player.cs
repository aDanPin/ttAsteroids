using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PhisicalView
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float speedOfBullet;
    private LineRenderer _lr;

    protected override void Start()
    {
        base.Start();

        _lr = GetComponent<LineRenderer>();

        InputEvents.current.onMoveTriggerEnter += Move;
        InputEvents.current.onRotateRightTriggerEnter += Rotate;
        InputEvents.current.onRotateLeftTriggerEnter  += Rotate;
        InputEvents.current.onFierTriggerEnter += Fier;
        InputEvents.current.onLaserTriggerEnter += Laser;
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

    private void Laser() {
        Vector2 start, direction, end;

        start = GetPosition();
        direction = Utils.Rotate(Vector2.up, GetRotation());
        end   = start + direction * 100;

        var hits = Physics2D.Raycast(start, direction,
                                     100f, LayerMask.NameToLayer("Enemy"));
    
        _lr.positionCount = 2;
        _lr.SetPosition(0, start);
        _lr.SetPosition(1, end);
    }

    protected override void OnCollision()
    {
        // base.OnCollision();
    }
}
