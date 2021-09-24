using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PhisicalView
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float speedOfBullet;
    [SerializeField]
    private float laserCooldown = 5;
    [SerializeField]
    private float laserDuration = 1;

    private float timePastAfterLiser = 0;
    private LineRenderer _lr;

    protected override void Start()
    {
        base.Start();

        _lr = GetComponent<LineRenderer>();
        timePastAfterLiser = laserCooldown;

        InputEvents.current.onMoveTriggerEnter += Move;
        InputEvents.current.onRotateRightTriggerEnter += Rotate;
        InputEvents.current.onRotateLeftTriggerEnter  += Rotate;
        InputEvents.current.onFierTriggerEnter += Fier;
        InputEvents.current.onLaserTriggerEnter += LaserStart;
    }

    private void Update() {
        DoLaserStuff();
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

    private void LaserStart() {
        if (timePastAfterLiser > laserCooldown) {
            timePastAfterLiser = 0;
            LaserCast();
        }
    }
 
    private void DoLaserStuff() {
        _lr.positionCount = 0;

        timePastAfterLiser += Time.deltaTime;
        if(timePastAfterLiser < laserDuration)
            LaserCast();   
    }

    private void LaserCast() {
        Vector2 start, direction, end;

        start = GetPosition();
        direction = Utils.Rotate(Vector2.up, GetRotation());
        end   = start + direction * 100;

        Ray2D ray = new Ray2D(start, direction);
        RaycastHit2D hit;
        hit = Physics2D.Raycast(start, direction, 10000f, LayerMask.GetMask("Enemy"));

        if(hit.transform != null) {
            hit.transform.gameObject.GetComponent<IPhisicalView>().OnCollision();
        }

        // Render laser
        _lr.positionCount = 2;
        _lr.SetPosition(0, start);
        _lr.SetPosition(1, end);
    }

    public override void OnCollision()
    {
        // base.OnCollision();
    }
}
