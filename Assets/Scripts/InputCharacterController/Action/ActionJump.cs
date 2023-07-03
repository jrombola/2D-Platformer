using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionJump : ActionObject
{
 
    public float PressTime;
    public float actionExpiryTime;
    bool WallJump = false;

    //constuctor
    public ActionJump()
    {
        PressTime = Time.time;
        actionExpiryTime = DataHolder.instance.Data.jumpInputBufferTime;
    }

    public bool CheckAction()
    {
        if (PressTime + actionExpiryTime >= Time.time)
        {
            if (canJump())
            {
                WallJump = false;
                return true;
            }
            else if (canWallJump())
            {
                WallJump = true;
                return true;
            }
        }
       
            return false;
    }

    public float checkTime()
    {
        return PressTime + actionExpiryTime;
    }

    private bool canJump()
    {
        return (DataHolder.instance.LastOnGround >= Time.time && !DataHolder.instance.isJumping);
    }

    private bool canWallJump()
    {
        return DataHolder.instance.LastWallTime > Time.time && (!DataHolder.instance.isWallJumping ||
            (DataHolder.instance.LastRightWallTime > Time.time && DataHolder.instance.wallJumpDir == 1) || (DataHolder.instance.LastLeftWallTime > Time.time && DataHolder.instance.wallJumpDir == -1));
    }

    

    public void ExecuteAction()
    {
        if (WallJump == false)
        {
            DataHolder.instance.LastOnGround = 0;
            DataHolder.instance.isJumping = true;
            DataHolder.instance.isWallJumping = false;
            DataHolder.instance.isJumpFalling = false;
            DataHolder.instance.isJumpCutting = false;
            ICommand Jump = new JumpCommand();
            Jump.Execute();
        }
        else
        {
            Debug.Log("WallJump");
            DataHolder.instance.isWallJumping = true;
            DataHolder.instance.isJumping = false;
            DataHolder.instance.isJumpCutting = false;
            DataHolder.instance.isJumpFalling = false;
            ICommand wallJump = new WallJumpCommand();
            wallJump.Execute();

            
        }
    }

}
