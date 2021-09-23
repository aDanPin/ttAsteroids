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

    struct ValueToInit {
        public ValueToInit(float r = 0, Vector2 d = default, float s = 0) {
            rotation = r;
            speedDirection = d;
            speedValue = s;
        }

        public float rotation;
        public Vector2 speedDirection;
        public float speedValue;
    }
    private ValueToInit valueToInit;

    protected virtual void Start() {
        id = commonId;
        commonId++;

        Debug.Log("Start called");
        Initialize();
        InitializeValues();
    }

    public void SetValueToInit(float rotationDegree, Vector2 speedDirection,
                          float speedValue) {
        valueToInit = new ValueToInit(rotationDegree, speedDirection, speedValue);
    }

    private void InitializeValues() {
        Rotate(valueToInit.rotation);
        SetVelocity(valueToInit.speedDirection,
                    valueToInit.speedValue);
    }

    public void Rotate(Vector2 dir) {
        _pp.Rotate(id, dir, rotateSpeed);
    }

    public void Rotate(float degree) {
        _pp.Rotate(id, degree);
    }

    public void SetVelocity(Vector2 dir, float val) {
        _pp.SetVelocity(id, dir, val);
    }

    public void ExertForce(Vector2 dir, float val, float time) {
        _pp.ExertForce(id, dir, val, time);
    }

    public void SetPosition(Vector2 pos) {
        transform.position = pos;
    }

    public void SetRotation(float dir) {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, dir));
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
