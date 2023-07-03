using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : ICommand
{
    
    public void Execute()
    {
        float targetVelocity = DataHolder.instance.movement.x * DataHolder.instance.Data.runMaxVelocity;
        
        if(DataHolder.instance.isWallJumping)
            targetVelocity = Mathf.Lerp(DataHolder.instance.rig.velocity.x, targetVelocity, DataHolder.instance.Data.wallJumpRunLerp);
        else
            targetVelocity = Mathf.Lerp(DataHolder.instance.rig.velocity.x, targetVelocity, 1);

        float accelRate;

        if (DataHolder.instance.LastOnGround > 0)
        {
            if (Mathf.Abs(targetVelocity) > 0.01f)
                accelRate = DataHolder.instance.Data.runAccelAmount;
            else
                accelRate = DataHolder.instance.Data.runDeccelAmount;
        }
        else
        {
            if (Mathf.Abs(targetVelocity) > 0.01f)
                accelRate = DataHolder.instance.Data.runAccelAmount * DataHolder.instance.Data.accelInAir;
            else
                accelRate = DataHolder.instance.Data.runDeccelAmount * DataHolder.instance.Data.deccelInAir;
        }

        if((DataHolder.instance.isJumping || DataHolder.instance.isWallJumping || DataHolder.instance.isJumpFalling)
            && Mathf.Abs(DataHolder.instance.rig.velocity.y) < DataHolder.instance.Data.jumpHangTimeThreshold)
        {
            accelRate *= DataHolder.instance.Data.jumpHangAccelerationMult;
            targetVelocity *= DataHolder.instance.Data.jumpHangMaxSpeedMult;
        }

        float velocityDifference = targetVelocity - DataHolder.instance.rig.velocity.x;

        float movement = velocityDifference * accelRate;

        DataHolder.instance.rig.AddForce(Vector2.right * movement, ForceMode2D.Force);
    }
}
