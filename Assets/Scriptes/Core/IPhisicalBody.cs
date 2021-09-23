using UnityEngine;

public interface IPhisicalBody
{
    Vector2 Position{get;}
    float Rotation{get;}
    void ExertForce(Vector2 dir, float value);
    void Rotate(Vector2 dir, float speed);
    void Rotate(float degree);
    void SetVelocity(Vector2 dir, float val);
    void PhisicalBodyUpdate();
}
