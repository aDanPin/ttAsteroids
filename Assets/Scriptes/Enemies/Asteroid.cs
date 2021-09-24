using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : PhisicalView
{
    public override void OnCollision() {
        GameEvents.current.asteroidDestroyTriggerEnter(GetPosition(), GetSpeed());

        base.OnCollision();
    }

    protected override void Dead()
    {
        base.Dead();
        ShowingMetrics.current.AddPoint();
    }
}
