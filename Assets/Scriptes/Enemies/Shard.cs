using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shard : PhisicalView
{
    protected override void Dead()
    {
        base.Dead();
        ShowingMetrics.current.AddPoint();
    }
}
