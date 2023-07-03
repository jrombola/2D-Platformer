using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCheck : MonoBehaviour
{

    void Update()
    {
        if (DataHolder.instance.isJumping && DataHolder.instance.rig.velocity.y < 0)
        {
            DataHolder.instance.isJumping = false;
            if (!DataHolder.instance.isWallJumping)
                DataHolder.instance.isJumpFalling = true;
        }

        if (DataHolder.instance.isWallJumping && Time.time - DataHolder.instance.wallJumpStartTime > DataHolder.instance.Data.wallJumpTime)
            DataHolder.instance.isWallJumping = false;

        if(DataHolder.instance.LastOnGround > 0 && !DataHolder.instance.isJumping && !DataHolder.instance.isWallJumping)
        {
            DataHolder.instance.isJumpCutting = false;
            if (!DataHolder.instance.isJumping)
                DataHolder.instance.isJumpFalling = false;
        }
    }

   
    
}
