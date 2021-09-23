using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPhisicalPresenter
{
    void AddView(IPhisicalView pv, int id, float mass, Vector2 pos);
    void DeleteView(int id);
    void SetVelocity(int id, Vector2 dir, float val);
    void Rotate(int id, Vector2 dir, float rotateSpeed);
    void Rotate(int id, float degree);
    void ExertForce(int id, Vector2 dir, float val, float time);
}