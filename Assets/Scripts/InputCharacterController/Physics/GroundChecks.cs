using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecks :Icheck
{
    public LayerMask _groundLayer = LayerMask.GetMask("Ground");
    private Vector2 _groundCheckSize = new Vector2(0.49f, 0.03f);


    public bool CollisionCheck()
    {
        Vector2 _groundCheckPoint = new Vector2(DataHolder.instance.rig.position.x, DataHolder.instance.rig.position.y - 1);

        if (Physics2D.OverlapBox(_groundCheckPoint, _groundCheckSize, 0, _groundLayer))
            return true;
        else
            return false;
    }


}
