using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhisicalView : MonoBehaviour, IPhisicalView
{
    static int commonId = 0;
    protected int id;

    [SerializeField]
    protected float rotateSpeed;
    [SerializeField]
    protected float mass = 1;
    [SerializeField]
    protected float moveForce = 10;

    protected IPhisicalPresenter _pp;

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

    public void SetForce(Vector2 dir, float val) {
        _pp.SetForce(id, dir, val);
    }

    public void ApplyPosition(Vector2 pos) {
        transform.position = pos;
    }

    public void ApplyRotation(float dir) {
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

    public float GetRotation() {
        return _pp.GetRotation(id);
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
