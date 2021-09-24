using UnityEngine;

public interface IPhisicalView
{
    void SetValueToInit(float rotationDegree, Vector2 speedDirection,
                        float speedValue);
    void Rotate(Vector2 dir);
    void Rotate(float degree);
    void SetVelocity(Vector2 dir, float val);
    void SetForce(Vector2 dir, float val);
    void ApplyPosition(Vector2 pos);
    void ApplyRotation(float dir);
    float GetRotation();
    Vector2 GetPosition();
    float GetSpeed();
    void OnCollision();
    void StartDestroy();
}
