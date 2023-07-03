using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCutCommand : ICommand
{
    public void Execute()
    {
        DataHolder.instance.isJumpCutting = true;
        DataHolder.instance.rig.gravityScale = DataHolder.instance.Data.gravityScale * DataHolder.instance.Data.jumpCutGravityMult;
        DataHolder.instance.rig.velocity = new Vector2(DataHolder.instance.rig.velocity.x,
            Mathf.Max(DataHolder.instance.rig.velocity.y, -DataHolder.instance.Data.maxFallVelocity));
    }
}
