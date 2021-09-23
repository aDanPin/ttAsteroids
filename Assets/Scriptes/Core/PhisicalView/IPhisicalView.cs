using UnityEngine;

public interface IPhisicalView
{
    void SetValueToInit(float rotationDegree, Vector2 speedDirection,
                          float speedValue);
    void Rotate(Vector2 dir);
    void Rotate(float degree);
    void SetVelocity(Vector2 dir, float val);
    void ExertForce(Vector2 dir, float val, float time);
    void SetPosition(Vector2 pos);
    void SetRotation(float dir);
    void StartDestroy();
}
