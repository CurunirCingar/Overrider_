using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public sealed class Ungravity : UI.Command {

    public override string Caption { get { return "Pause physics simulation"; } }
    public override int Cost { get { return 24; } }
    public override int ActiveTime
    {
        get
        {
            return 5;
        }
    }
    Rigidbody rbody;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody>();
    }

    public override void Activate()
    {
        base.Activate();
        rbody.isKinematic = true;
    }

    public override void Disable()
    {
        base.Disable();
        rbody.isKinematic = false;
    }
}
