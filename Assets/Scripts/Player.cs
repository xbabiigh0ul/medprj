using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float gravity;
    public float velocity;
    public float maxXVelocity = 100;
    public float maxAcceleration = 8;
    public float acceleration = 0.5f;
    public float distance = 0;
    public float jumpVelocity = 20;
    public float groundHeight = 10;
    public bool isGrounded = false;

    public bool isHoldingJump = false;
    public float maxHoldJumpTime = 0.4f;
    public float maxMaxHoldJumpTime = 0.4f;
    public float holdJumpTimer = 0.0f;

    public float jumpGroundThreshold = 1;
    

    public bool isDead = false;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isGrounded && !isHoldingJump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isGrounded = false;
                //rb.AddExplosionForce(5.0f, transform.position, 0.0f);
                rb.AddRelativeForce(Vector3.up * 2300.0f, ForceMode.Impulse);
                isHoldingJump = true;
                holdJumpTimer = 0;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isHoldingJump = false;
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(Physics.gravity, ForceMode.Acceleration);

        Vector2 pos = transform.position;

        if (isDead)
        {
            return;
        }

        if (pos.y < -20)
        {
            isDead = true;
        }

        if (!isGrounded)
        {
            if (isHoldingJump)
            {
                holdJumpTimer += Time.fixedDeltaTime;
                if (holdJumpTimer >= maxHoldJumpTime)
                {
                    isHoldingJump = false;
                }
            }
        }

        distance += velocity * Time.fixedDeltaTime;

        if (isGrounded)
        {
            // float velocityRatio = velocity / maxXVelocity;
            // acceleration = maxAcceleration * (1 - velocityRatio);
            maxHoldJumpTime = maxMaxHoldJumpTime; // * velocityRatio;

            velocity += acceleration * (Time.fixedDeltaTime * 0.5f);
            if (velocity >= maxXVelocity)
            {
                velocity = maxXVelocity;
            }
        }

        transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
}
