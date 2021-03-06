using UnityEngine;

public class PhisicalBody : IPhisicalBody
{
    private Vector2 position;
    private float direction; // Velue of angle  between Vector2.up
                             // and direction of object
    private Vector2 velocity;
    private Vector2 acceleration;
    private float mass;
    private float maxHorisontalDelta;
    private float maxVerticalDelta; 
    private Vector2 forceHub = Vector2.zero;
    private const float DELTA_TIME = 0.01f;

    public Vector2 Position{get{return position;}}
    public float Rotation{get{return direction;}}
    public float Speed{get{return velocity.magnitude;}}

    public PhisicalBody(Vector2 p = default(Vector2), float m = 1,
                 float d   = 0f,
                 Vector2 v = default(Vector2),
                 Vector2 a = default(Vector2)) {
        position     = p;
        direction    = d;
        velocity     = v;
        acceleration = a;
        mass         = m;

        maxHorisontalDelta = Camera.main.ScreenToWorldPoint(
                                  new Vector2(Screen.width, 0)).x;
        maxVerticalDelta   = Camera.main.ScreenToWorldPoint(
                                  new Vector2(0, Screen.height)).y;
    }

    public void ExertForce(Vector2 dir, float value) {
        // The direction here is relative to the direction of the body
        Vector2 actualDir = Utils.Rotate(dir, direction);

        forceHub += actualDir.normalized * value;
    }

    public void PhisicalBodyUpdate() {
        acceleration = forceHub / mass;

        velocity = velocity + acceleration * DELTA_TIME;

        position = position + velocity * DELTA_TIME;

        CheckAndFixPosition();

        forceHub = Vector2.zero;
    }

    private void CheckAndFixPosition() {
        if(position.x > maxHorisontalDelta) {
            Vector2 newPos = position;
            newPos.x = -maxHorisontalDelta;
            newPos.y = -newPos.y;

            position = newPos;
        }
        else if(position.x < -maxHorisontalDelta){
            Vector2 newPos = position;
            newPos.x = maxHorisontalDelta;
            newPos.y = -newPos.y;

            position = newPos;
        }
        else if(position.y > maxVerticalDelta) {
            Vector2 newPos = position;
            newPos.y = -maxVerticalDelta;
            newPos.x = -newPos.x;

            position = newPos;
        }
        else if(position.y < -maxVerticalDelta){
            Vector2 newPos = position;
            newPos.y = maxVerticalDelta;
            newPos.x = -newPos.x;

            position = newPos;
        }
    }

    public void Rotate(Vector2 dir, float speed) {
        if(dir == Vector2.left)  RotateP( speed);
        if(dir == Vector2.right) RotateP(-speed);
    }

    public void Rotate(float degree) {
        RotateP(degree);
    }

    private void RotateP(float speed) {
        direction += speed;
    }

    public void SetVelocity(Vector2 dir, float val) {
        velocity = dir.normalized * val;
    }
}
