using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Bounced : UI.Command {

    public override string Caption { get { return "Physics bounce glitch"; } }
    public override int Cost { get { return 20; } }

    public override int ActiveTime
    {
        get
        {
            return 5;
        }
    }

    const float bounceScale = 20;

    bool isBouncyEnabled;

    public override void Activate()
    {
        base.Activate();
        isBouncyEnabled = true;
    }

    public override void Disable()
    {
        base.Disable();
        isBouncyEnabled = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isBouncyEnabled)
            return;

        Rigidbody otherRB = collision.collider.gameObject.GetComponent<Rigidbody>();

        if (otherRB != null)
        {
            Debug.Log(otherRB.velocity.y);
            otherRB.AddForce(Vector3.up * bounceScale, ForceMode.VelocityChange);
        }
        else
        {
            Debug.Log("In Bouncing rigidbody not found.");
        }
    }

    
}
