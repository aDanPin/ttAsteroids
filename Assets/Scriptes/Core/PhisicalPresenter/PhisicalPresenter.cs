using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhisicalPresenter : MonoBehaviour, IPhisicalPresenter
{
    [SerializeField]
    private Dictionary<int, IPhisicalView> views;
    private IPhisicalModel _pm;

    private void Awake() {
        views = new Dictionary<int, IPhisicalView>();
        InitializeModel();
    }

    private void FixedUpdate() {
        _pm.UpdatePhisicals();

        foreach(int key in views.Keys) {
            Vector2 pos = _pm.GetPosition(key);
            float rot   = _pm.GetRotation(key);

            views[key].ApplyPosition(pos);
            views[key].ApplyRotation(rot);
        }
    }

    public void AddView(IPhisicalView pv, int id, float mass,
                        Vector2 pos) {
        if(views == null) {
            views = new Dictionary<int, IPhisicalView>();
        }
        views.Add(id, pv);

        if (_pm == null) Debug.Log("Null model");
        _pm.AddModel(id, mass, pos);
    }

    public void DeleteView(int id) {
        views.Remove(id);

        _pm.RemoveModel(id);
    }

    public void Rotate(int id, Vector2 dir, float rotateSpeed) {
        _pm.Rotate(id, dir, rotateSpeed);
    }

    public void Rotate(int id, float degree) {
        _pm.Rotate(id, degree);
    }

    public void SetVelocity(int id, Vector2 dir, float val) {
        _pm.SetVelocity(id, dir, val);
    }

    public void SetForce(int id, Vector2 dir, float val) {
        _pm.SetForce(id, dir, val);
    }

    public float GetRotation(int id) {
        return _pm.GetRotation(id);
    }

    public Vector2 GetPosition(int id) {
        return _pm.GetPosition(id);
    }

    public float GetSpeed(int id) {
        return _pm.GetSpeed(id);
    }

    private void InitializeModel() {
        _pm = gameObject.AddComponent<PhisicalModel>();

        if(_pm == null) {
            Debug.Log("Empty model");
        }
    }

    private void OnDestroy() {
        ClearModel();
        ClearViews();
    }

    private void ClearModel() {
        _pm.Clear();
    }

    private void ClearViews() {
        foreach(int key in views.Keys) {
            views[key].StartDestroy();
            views.Remove(key);
        }
    }
}
