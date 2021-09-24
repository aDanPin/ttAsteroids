using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    // private InputActions _ia;

    private bool moveHeld = false;
    private bool raotateRight = false;
    private bool rotateLeft = false;

    protected override void Start()
    {
        base.Start();

        // _ia = new InputActions();

        _lr = GetComponent<LineRenderer>();
        timePastAfterLiser = laserCooldown;
    }

    private void FixedUpdate() {
        DoInputStuff();
    }

    private void Update() {
        DoLaserStuff();
        ShowMetrics();
    }

    private void ShowMetrics() {
        float r = GetRotation();
        r %= 360;
        r = r >= 0 ? r : 360 + r;    

        float cd = laserCooldown - timePastAfterLiser;
        cd = cd > 0 ? cd : 0;

        ShowingMetrics.current.UpdateMetrisc(GetPosition(),
                                             r,
                                             GetSpeed(),
                                             cd);
    }

    private void DoInputStuff() {
        if(moveHeld)
            Move();
        if(rotateLeft)
            Rotate(Vector2.left);
        if(raotateRight)
            Rotate(Vector2.right);
    }

    public void OnMove() {
        moveHeld = !moveHeld;
    }

    private void Move() {
        SetForce(Vector2.up, moveForce);
    }

    public void OnFier() {
        Fier();
    }

    private void Fier() {
        var bulletView = Instantiate(bullet, GetPosition(),Quaternion.identity)
                             .GetComponent<IPhisicalView>();

        Vector2 speedDirection = Utils.Rotate(Vector2.up, GetRotation()); 

        bulletView.SetValueToInit(GetRotation(),
                                  speedDirection,
                                  speedOfBullet);
    }

    public void OnRotationLeft() {
        rotateLeft = !rotateLeft;
    }

    public void OnRotationRight() {
        raotateRight = !raotateRight;
    }

    public void OnLaser() {
        LaserStart();
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
        end   = start + direction * 100; // 100 - just a long of line

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
        DeadManager.current.OnPlayerDead();
    }
}
