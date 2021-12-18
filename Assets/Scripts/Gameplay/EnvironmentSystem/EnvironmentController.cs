using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BounceAxis
{
    BOUNCE_UP,
    BOUNCE_RIGHT,
    BOUNCE_LEFT
}

public interface IBouncer
{
    void Bounce(IBounceable bouncer);
}

public class EnvironmentController : MonoBehaviour, IBouncer
{

    public BounceAxis bounceAxis;
    public void OnTriggerEnter(Collider other)
    {
        IBounceable bouncer = other.gameObject.GetComponent<IBounceable>();
        if (bouncer != null)
        {
            Bounce(bouncer);
        }
    }

    public void Bounce(IBounceable bounceable)
    {
        BouncerData bouncerData = bounceable.GetBouncerData();
        Rigidbody rb = bouncerData.rigidbody;
        Vector3 newVelocity = rb.velocity;
        Debug.Log("Bouncing object " + bounceable.GetBouncerData().rigidbody.gameObject.name);
        switch (bounceAxis)
        {
            case BounceAxis.BOUNCE_UP:
                Debug.Log(newVelocity);
                if (rb.velocity.y < 0)
                {
                    newVelocity.y = newVelocity.y * -1;
                    Debug.Log(newVelocity);
                    newVelocity = newVelocity.normalized * bouncerData.GetBounceSpeed();
                }
                break;
            case BounceAxis.BOUNCE_RIGHT:
                if (rb.velocity.x < 0)
                {
                    newVelocity.x = newVelocity.x * -1;
                    //newVelocity = newVelocity.normalized * bouncerData.GetBounceSpeed();
                }
                break;
            case BounceAxis.BOUNCE_LEFT:
                if (rb.velocity.x > 0)
                {
                    newVelocity.x = newVelocity.x * -1;
                    //newVelocity = newVelocity.normalized * bouncerData.GetBounceSpeed();
                }
                break;
            default:
                break;
        }
        Debug.Log(newVelocity);
        rb.velocity = newVelocity;
    }

}
