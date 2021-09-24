using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : PhisicalView
{
    [SerializeField]
    private float Speed;

    private GameObject player;

    protected override void Start()
    {
       base.Start();
    
        player = GameObject.FindWithTag("Player");
    }

    private void Update() {
        MoveToPlayer();
        // RotateToPlayer();
    }

    private void MoveToPlayer() {
        Vector2 target = player.transform.position;
        Vector2 current = transform.position;

        Vector2 moveVector = target - current;

        Debug.DrawLine(current, current + moveVector, Color.red, 0.1f);

        SetVelocity(moveVector, Speed);
    }

    private void RotateToPlayer() {
        Vector2 targetVector = player.transform.position - transform.position;
        float targetAngle = Vector2.Angle(Vector2.up, targetVector);

        float currentAngle = GetRotation();

        float rotateAngle = targetAngle - currentAngle;
    
        Rotate(rotateAngle);
    }
}
