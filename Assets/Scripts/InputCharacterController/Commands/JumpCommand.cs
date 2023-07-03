using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCommand : ICommand
{
    public void Execute()
    {
        float force = DataHolder.instance.Data.jumpForce;
        Rigidbody2D rig = DataHolder.instance.rig;
        if (rig.velocity.y < 0)
            rig.velocity = new Vector2(DataHolder.instance.rig.velocity.x, 0f); 
           
        rig.AddForce(Vector2.up * DataHolder.instance.Data.jumpForce, ForceMode2D.Impulse);
        
    }
}
