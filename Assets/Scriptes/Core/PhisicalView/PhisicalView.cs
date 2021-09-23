using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhisicalView : MonoBehaviour, IPhisicalView
{
    static int commonId = 0;
    private int id;

    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private float mass = 1;

    private IPhisicalPresenter _pp;

    protected void Awake() {
        id = commonId;
        commonId++;

        Initialize();
    }

    public void Rotate(Vector2 dir) {
        _pp.Rotate(id, dir, rotateSpeed);
    }

    public void ExertForce(Vector2 dir, float val, float time) {
        _pp.ExertForce(id, dir, val, time);
    }

    public void SetPosition(Vector2 pos) {
        transform.position = pos;
    }

    public void SetRotation(Vector2 dir) {
        // Check first!!
        float angle = Vector2.Angle(Vector2.up, dir);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void Initialize() {
        _pp = GameObject.FindGameObjectWithTag("PhisicalPresenter")
                .GetComponent<IPhisicalPresenter>();

        if(_pp == null) {
            Debug.Log("Empty presenter");
        }

        _pp.AddView(this, id, mass, transform.position);
    }

    public void StartDestroy() {
        Destroy(gameObject);
    }

    private void Dead() {
        _pp.DeleteView(id);
    }

    private void OnDestroy() {
        Dead();
    }
}
