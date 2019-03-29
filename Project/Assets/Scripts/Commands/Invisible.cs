using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Invisible : UI.Command {

  public override string Caption { get { return "Mesh corruption"; } }
  public override int Cost { get { return 10; } }
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
        GetComponent<MeshRenderer>().enabled = false;
    }

    public override void Disable()
    {
        base.Disable();
        GetComponent<MeshRenderer>().enabled = false;
    }
}
