using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public sealed class ReverseGravity : UI.Command {

    public override string Caption { get { return "ReverseGravity"; } }
    public override int Cost { get { return 33; } }
    public override int ActiveTime
    {
        get
        {
            return 5;
        }
    }
    bool isReverseGravityEnabled;
    Rigidbody chachedRig;

    float activeTime = 3f;

    void Start()
    {
        chachedRig = GetComponent<Rigidbody>();
    }

    public override void Activate()
    {
        base.Activate();
        isReverseGravityEnabled = true;
        chachedRig.useGravity = false;
        chachedRig.angularDrag = 100;
    }

    public override void Disable()
    {
        base.Disable();
        isReverseGravityEnabled = false;
        chachedRig.useGravity = true;
        chachedRig.angularDrag = 0;
    }

    void FixedUpdate()
    {
        if (isReverseGravityEnabled)
        {
            chachedRig.AddForce(-Physics.gravity * chachedRig.mass);
        }
    }
}
