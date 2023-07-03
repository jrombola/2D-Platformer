using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : MonoBehaviour
{
    public static DataHolder instance;

    //debug helper
    public float time;
    public GameObject testObject;

    public PlayerData Data;
    public Rigidbody2D rig;
    public Vector2 movement;

    //control variables
    public bool facingRight;
    public bool isJumping;
    public bool isWallJumping;
    public bool isSliding;

    //Timers
    public float LastOnGround;
    public float LastWallTime;
    public float LastLeftWallTime;
    public float LastRightWallTime;

    //Jumps
    public bool isJumpCutting;
    public bool isJumpFalling;

    //wallJumps
    public float wallJumpStartTime;
    public int wallJumpDir;

    private void Awake()
    {
        instance = this;
        rig.gravityScale = Data.gravityScale;
        facingRight = true;
    }

    private void Update()
    {
        time = Time.time;
    }

}
