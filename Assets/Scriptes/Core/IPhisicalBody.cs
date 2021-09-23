using UnityEngine;

public interface IPhisicalBody
{
    Vector2 Position{get;}
    Vector2 Rotation{get;}
    void ExertForce(Vector2 dir, float value);
    void PhisicalBodyUpdate();
}
