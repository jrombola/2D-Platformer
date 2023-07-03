using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigGravity : MonoBehaviour
{

    private void Update()
    {

        if (DataHolder.instance.isSliding)
            setGravityScale(0);
        else if (DataHolder.instance.isJumpCutting)
        {
            DataHolder.instance.rig.gravityScale = DataHolder.instance.Data.gravityScale * DataHolder.instance.Data.jumpCutGravityMult;
            DataHolder.instance.rig.velocity = new Vector2(DataHolder.instance.rig.velocity.x,
                Mathf.Max(DataHolder.instance.rig.velocity.y, -DataHolder.instance.Data.maxFallVelocity));
        }
        else if ((DataHolder.instance.isJumping || DataHolder.instance.isWallJumping || DataHolder.instance.isJumpFalling)
            && Mathf.Abs(DataHolder.instance.rig.velocity.y) < DataHolder.instance.Data.jumpHangTimeThreshold)
        {
            setGravityScale(DataHolder.instance.Data.gravityScale * DataHolder.instance.Data.jumpHangGravityMult);
        }

        else if (DataHolder.instance.rig.velocity.y <= 0)
        {
            DataHolder.instance.isJumping = false;
            setGravityScale(DataHolder.instance.Data.gravityScale * DataHolder.instance.Data.fallGravityMult);
            DataHolder.instance.rig.velocity = new Vector2(DataHolder.instance.rig.velocity.x,
                Mathf.Max(DataHolder.instance.rig.velocity.y, -DataHolder.instance.Data.maxFallVelocity));
        }
        else
            setGravityScale(DataHolder.instance.Data.gravityScale);

    }
    public void setGravityScale(float scale)
    {
        DataHolder.instance.rig.gravityScale = scale;
    }
}
