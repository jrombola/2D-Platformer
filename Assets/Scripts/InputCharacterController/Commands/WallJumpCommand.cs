using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumpCommand : ICommand
{
    public void Execute()
    {
        DataHolder.instance.wallJumpStartTime = Time.time;
        
        if (DataHolder.instance.LastRightWallTime > 0)
            DataHolder.instance.wallJumpDir = -1;
        else
            DataHolder.instance.wallJumpDir = 1;

        DataHolder.instance.LastOnGround = 0;
        DataHolder.instance.LastLeftWallTime = 0;
        DataHolder.instance.LastRightWallTime = 0;
        DataHolder.instance.LastWallTime = 0;

        Vector2 force = new Vector2(DataHolder.instance.Data.WallJumpForce.x, DataHolder.instance.Data.WallJumpForce.y);
        force.x *= DataHolder.instance.wallJumpDir;

        if (Mathf.Sign(DataHolder.instance.rig.velocity.x) != Mathf.Sign(force.x))
            force.x -= DataHolder.instance.rig.velocity.x;

        if(DataHolder.instance.rig.velocity.y < 0)
            force.y -= DataHolder.instance.rig.velocity.y;
        DataHolder.instance.rig.AddForce(force, ForceMode2D.Impulse);

    }
}
