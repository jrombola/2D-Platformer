using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallChecks : Icheck
{
    public LayerMask _groundLayer = LayerMask.GetMask("Ground");
    private Vector2 _wallCheckSize = new Vector2(0.2f, 1f);
    public float offset;

    public bool CollisionCheck()
    {
        Vector2 _WallCheckPoint = new Vector2((DataHolder.instance.rig.position.x) + offset * Mathf.Sign(DataHolder.instance.rig.gameObject.transform.localScale.x), 
            DataHolder.instance.rig.position.y);

        Collider2D test = Physics2D.OverlapBox(_WallCheckPoint, _wallCheckSize, 0, _groundLayer);
        if (test && test.tag == "Wall")
        {
            Debug.Log("1");
            return true;
        }
        else
        {
            Debug.Log("2");
            return false;
        }
    }
}
