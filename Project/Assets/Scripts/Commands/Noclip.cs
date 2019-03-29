using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Noclip : UI.Command {

  public override string Caption { get { return "Collision disabled"; } }
  public override int Cost { get { return 23; } }
    public override int ActiveTime
    {
        get
        {
            return 5;
        }
    }
    public override void Activate()
    {
        base.Activate();
        GetComponent<Collider>().enabled = false;
    }

    public override void Disable()
    {
        base.Disable();
        GetComponent<Collider>().enabled = true;
    }
}
