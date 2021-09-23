using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhisicalModel : MonoBehaviour, IPhisicalModel
{
    [SerializeField]
    private Dictionary<int, IPhisicalBody> bodies;

    private void Awake() {
        bodies = new Dictionary<int, IPhisicalBody>();
    }

    public void AddModel(int id, float mass, Vector2 pos) {
        IPhisicalBody pb = new PhisicalBody(pos, mass);

        bodies.Add(id, pb);
    }

    public void RemoveModel(int id) {
        bodies.Remove(id);
    }

    public void Rotate(int id, Vector2 dir, float speed) {
        bodies[id].Rotate(dir, speed);
    }

    public void Rotate(int id, float degree) {
        bodies[id].Rotate(degree);
    }

    public void SetVelocity(int id, Vector2 dir, float val) {
        bodies[id].SetVelocity(dir, val);
    }

    public void ExertForce(int id, Vector2 dir, float val, float time) {
        bodies[id].ExertForce(dir, val);
    }
    
    public void UpdatePhisicals() {
        foreach(int key in bodies.Keys) {
            bodies[key].PhisicalBodyUpdate();
        }
    }

    public Vector2 GetPosition(int id) {
        return bodies[id].Position;
    }

    public float GetRotation(int id) {
        return bodies[id].Rotation;
    }

    public void Clear() {
        bodies.Clear();
    }
}
