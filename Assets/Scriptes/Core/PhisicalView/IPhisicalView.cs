using UnityEngine;

public interface IPhisicalView
{
    void Rotate(Vector2 dir);
    void ExertForce(Vector2 dir, float val, float time);
    void SetPosition(Vector2 pos);
    void SetRotation(float dir);
    void StartDestroy();
}
