using UnityEngine;

public interface IPhisicalBody
{
    void ExertForce(Vector2 dir, float value);
    void PhisicalBodyUpdate();
}
