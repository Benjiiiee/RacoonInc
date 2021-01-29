using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharacterController : KinematicObject
{

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public float maxJumpSpeed = 7;

    public JumpState jumpState = JumpState.Grounded;
    private bool stopJump;
    public Collider2D collider2d;
    public bool controlEnabled = true;

    bool jump;
    Vector2 move;
    SpriteRenderer spriteRenderer;
    public float jumpModifier = 1.5f;
    public float jumpDeceleration = 0.5f;
    //RaycastHit2D[] results;
    public RaycastHit2D hit;

    public ColliderCheck colliderRight;
    public ColliderCheck colliderLeft;

    public Bounds Bounds => collider2d.bounds;

    void Awake()
    {
        collider2d = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        colliderRight = colliderRight.GetComponent<ColliderCheck>();
        colliderLeft = colliderLeft.GetComponent<ColliderCheck>();
    }

    protected override void Update()
    {
        if (controlEnabled)
        {
            move.x = Input.GetAxis("Horizontal");
            if (jumpState == JumpState.Grounded && Input.GetButtonDown("Jump"))
                jumpState = JumpState.PrepareToJump;
            else if (Input.GetButtonUp("Jump"))
            {
                stopJump = true;
                //Schedule<PlayerStopJump>().player = this;
            }
        }
        else
        {
            move.x = 0;
        }
        UpdateJumpState();
        base.Update();
    }



        void UpdateJumpState()
    {
        jump = false;
        switch (jumpState)
        {
            case JumpState.PrepareToJump:
                jumpState = JumpState.Jumping;
                jump = true;
                stopJump = false;
                break;
            case JumpState.Jumping:
                if (!IsGrounded)
                {
                  //  Schedule<PlayerJumped>().player = this;
                    jumpState = JumpState.InFlight;
                }
                break;
            case JumpState.InFlight:
                if (IsGrounded)
                {
                   // Schedule<PlayerLanded>().player = this;
                    jumpState = JumpState.Landed;
                }
                break;
            case JumpState.Landed:
                jumpState = JumpState.Grounded;
                break;
        }
    }

    protected override void ComputeVelocity()
    { 
        if (jump && IsGrounded)
        {
            velocity.y = jumpTakeOffSpeed * jumpModifier;
            jump = false;
        }
        else if (stopJump)
        {
            stopJump = false;
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * jumpDeceleration;
            }
        }

        if (move.x > 0.01f)
            spriteRenderer.flipX = false;
        else if (move.x < -0.01f)
            spriteRenderer.flipX = true;

        if (spriteRenderer.flipX)
        {
            if (colliderLeft.colliding)
            {
                move.x = 0f;
            }
        }
        else if (colliderRight.colliding)
        {
            move.x = 0f;
        }

        if (IsGrounded)
        {
            targetVelocity = move * maxSpeed;
        }
        else
        {
            targetVelocity = move * maxJumpSpeed;
        }
        
    }

    public enum JumpState
    {
        Grounded,
        PrepareToJump,
        Jumping,
        InFlight,
        Landed
    }
}
