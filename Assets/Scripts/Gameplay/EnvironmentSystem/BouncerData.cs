using System;
using UnityEngine;

[Serializable]
public class BouncerData
{
    [HideInInspector]
    public Rigidbody rigidbody;
    public float bounceSpeed = 3f;

    public void Setup(Rigidbody rb)
    {
        rigidbody = rb;
    }

    public float GetBounceSpeed()
    {
        return bounceSpeed;
    }

}
