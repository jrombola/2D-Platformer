using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsChecker : MonoBehaviour
{
    GroundChecks groundCheck;
    WallChecks frontCheck;
    WallChecks backCheck;
    public float offsetF = 0.5f;
    public float offsetB = -0.5f;

    private void Awake()
    {
        groundCheck = new GroundChecks();
        frontCheck = new WallChecks();
        backCheck = new WallChecks();
        frontCheck.offset = offsetF;
        backCheck.offset = offsetB;
    }
  
    private void Update()
    {     
        if (groundCheck.CollisionCheck() && !DataHolder.instance.isJumping)
        {
            DataHolder.instance.isJumpCutting = false;
            DataHolder.instance.LastOnGround = Time.time + DataHolder.instance.Data.coyoteTime;
        }

        if (((frontCheck.CollisionCheck() && DataHolder.instance.facingRight) || (backCheck.CollisionCheck() && !DataHolder.instance.facingRight))
            && !DataHolder.instance.isWallJumping)
        {
            DataHolder.instance.LastRightWallTime = Time.time + DataHolder.instance.Data.coyoteTime; 
        }
        if(((frontCheck.CollisionCheck() && !DataHolder.instance.facingRight) || (backCheck.CollisionCheck() && DataHolder.instance.facingRight)) 
            && !DataHolder.instance.isWallJumping)
        {
            DataHolder.instance.LastLeftWallTime = Time.time + DataHolder.instance.Data.coyoteTime;
        }

        DataHolder.instance.LastWallTime = Mathf.Max(DataHolder.instance.LastLeftWallTime, DataHolder.instance.LastRightWallTime);
    }

    private void OnDrawGizmosSelected()
    {
        Vector2 _groundCheckSize = new Vector2(0.49f, 0.03f);
        Vector2 _groundCheckPoint = new Vector2(DataHolder.instance.rig.position.x, DataHolder.instance.rig.position.y - 1);
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(_groundCheckPoint, _groundCheckSize);

        
        Gizmos.color = Color.blue;
        Vector2 _WallCheckPoint = new Vector2((DataHolder.instance.rig.position.x) + offsetF * Mathf.Sign(DataHolder.instance.rig.gameObject.transform.localScale.x),
            DataHolder.instance.rig.position.y);
        Vector2 _wallCheckSize = new Vector2(0.2f, 1f);
        Gizmos.DrawWireCube(_WallCheckPoint, _wallCheckSize);
        _WallCheckPoint.x = (DataHolder.instance.rig.position.x) + offsetB * Mathf.Sign(DataHolder.instance.rig.gameObject.transform.localScale.x);
        Gizmos.DrawWireCube(_WallCheckPoint, _wallCheckSize);

        Gizmos.color = Color.white;
        Gizmos.DrawRay(Vector3.left, new Vector3((DataHolder.instance.rig.position.x + (0.52f * Mathf.Sign(DataHolder.instance.rig.position.x))), DataHolder.instance.rig.position.y - 0.3f, 0f));

    }
}
