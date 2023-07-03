using UnityEngine;

[CreateAssetMenu(menuName = "Player Data")]
public class PlayerData : ScriptableObject
{
    [Header("Gravity")]
    [HideInInspector] public float gravityStrength;
    [HideInInspector] public float gravityScale;
    public float fallGravityMult;
    public float maxFallVelocity;

    [Space(5)]

    [Header("Movement")]
    public float runMaxVelocity;
    public float runAcceleration;
    [HideInInspector] public float runAccelAmount;
    public float runDecceleration;
    [HideInInspector] public float runDeccelAmount;
    [Space(10)]
    [Range(0.01f, 1)] public float accelInAir; //Multiplier used for acceleration in the air
    [Range(0.01f, 1)] public float deccelInAir;
    
    [Space(20)]
    
    [Header("Jump")]
    public float jumpHeight;
    public float jumpTimeToApex;
    [HideInInspector] public float jumpForce;

    [Space(0.5f)]

    [Header("Both Jumps")]
    public float jumpCutGravityMult;
    [Range(0f, 1)] public float jumpHangGravityMult;
    public float jumpHangTimeThreshold;
    
    [Space(0.5f)]
    
    public float jumpHangAccelerationMult;
    public float jumpHangMaxSpeedMult;

    [Header("Wall Jump")]
    public Vector2 WallJumpForce;
    [Space(5)]
    [Range(0f, 1f)] public float wallJumpRunLerp; 
    [Range(0f, 1.5f)] public float wallJumpTime; 
    public bool doTurnOnWallJump;

    [Space(20)]

    [Header("Wall Slide")]
    public float slideVelocity;
    public float slideAcelleration;

    [Header("Assists")]
    [Range(0.01f, 0.5f)] public float coyoteTime;
    [Range(0.01f, 0.5f)] public float jumpInputBufferTime;

    private void OnValidate()
    {

        //Calculating magnitude of gravity Strength the setting player gravityScale based on its ratio
        //uses kinematic formula yf - y0 = vf*t - 1/2 * a*t^2 where vf = 0, yf = jumpHeight, y0 = 0 t = jumpTimeToApex  
        gravityStrength = -(2 * jumpHeight) / (jumpTimeToApex * jumpTimeToApex); 

        //Calculates rigidBody's gravity scale (how much gravity effects player) 
        gravityScale = gravityStrength / Physics2D.gravity.y;

        //Calculates how much to accelerate by 
        runAccelAmount = (50 * runAcceleration) / runMaxVelocity; 
        runDeccelAmount = (50 * runDecceleration) / runMaxVelocity;
        
        //Calculated using kinematic formula vf = vi + a*t where vf = 0 vi = jumpForce, a = acceleration, t = time until jump apex
        jumpForce = Mathf.Abs(gravityStrength) * jumpTimeToApex;

        #region Variable Ranges
        runAcceleration = Mathf.Clamp(runAcceleration, 0.01f, runMaxVelocity);
        runDecceleration = Mathf.Clamp(runDecceleration, 0.01f, runMaxVelocity);
        #endregion
    }

}


