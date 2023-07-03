using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionJumpCut : ActionObject
{
    public float PressTime;
    public float actionExpiryTime = 500;

    //constuctor
    public ActionJumpCut()
    {
        PressTime = Time.time;
        actionExpiryTime = DataHolder.instance.Data.jumpTimeToApex;
    }

    public bool CheckAction()
    {
        if (DataHolder.instance.rig.velocity.y > 0)
            return true;
        else
        {
            PressTime = 0;
            actionExpiryTime = 0;
            return false;
        }
    }

    public float checkTime()
    {
        return PressTime + actionExpiryTime;
    }

    public void ExecuteAction()
    {
        ICommand JumpCut = new JumpCutCommand();
        JumpCut.Execute();
    }

}

