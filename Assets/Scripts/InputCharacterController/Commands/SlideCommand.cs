using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideCommand : ICommand
{
    public void Execute()
    {
        if (CanSlide() && ((DataHolder.instance.LastLeftWallTime > Time.time && DataHolder.instance.movement.x < 0) || (DataHolder.instance.LastRightWallTime > Time.time && DataHolder.instance.movement.x > 0)))
            DataHolder.instance.isSliding = true;
        else
            DataHolder.instance.isSliding = false;

        if (DataHolder.instance.isSliding)
        {
            
            float VelocityDifference = DataHolder.instance.Data.slideVelocity - DataHolder.instance.rig.velocity.y;
            float movement = VelocityDifference * DataHolder.instance.Data.slideAcelleration;
            movement = Mathf.Clamp(movement, -Mathf.Abs(VelocityDifference) * 50, Mathf.Abs(VelocityDifference) * 50);
            DataHolder.instance.rig.AddForce(movement * Vector2.up);

            //DataHolder.instance.rig.velocity = new Vector2(DataHolder.instance.rig.velocity.x, DataHolder.instance.Data.slideVelocity);
        }
    }
    private bool CanSlide()
    {
        if (DataHolder.instance.LastWallTime > 0 && !DataHolder.instance.isJumping && DataHolder.instance.LastOnGround <= 0)
            return true;
        else
            return false;
    }




}
