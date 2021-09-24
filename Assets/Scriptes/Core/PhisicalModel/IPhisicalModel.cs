using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPhisicalModel {
    void AddModel(int id, float mass, Vector2 pos);
    void RemoveModel(int id);
    void SetForce(int id, Vector2 dir, float val);
    void SetVelocity(int id, Vector2 dir, float val);
    void Rotate(int id, Vector2 dir, float speed);
    void Rotate(int id, float degree);
    void UpdatePhisicals();
    Vector2 GetPosition(int id);
    float GetRotation(int id);
    void Clear();
}
